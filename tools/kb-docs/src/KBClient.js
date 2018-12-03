const WebSocket = require('ws');
const debug = require('debug')('kb-docs:kbclient');
const config = require('../config.json');

class Deferred {
    constructor(timeout = 5000) {

        // Register the timeout handler
        const t = setTimeout(() => {
            this.reject(new Error('Timeout.'));
        }, timeout);

        // Create a new unresolved promise and keep a reference to the `resolve` and `reject` methods
        this.promise = new Promise((resolve, reject) => {
            this.resolve = x => {
                clearTimeout(t);
                resolve(x);
            };
            this.reject = e => {
                clearTimeout(t);
                reject(e);
            };
        });

    }
};

module.exports = class KBClient {
    
    constructor(ws, token) {
        if (!ws || !(ws instanceof WebSocket) || ws.readyState !== WebSocket.OPEN) {
            throw new Error('KBClient must be initialized with an already connected WebSocket.');
        }
        this._ws = ws;
        this._token = token;
        this._pendingRequests = [];

        ws.on('error close', this._onError.bind(this));
        ws.on('message', this._onMessage.bind(this));
    }

    /**
     * Connects to the KB and returns a new instance of a `KBClient`.
     * 
     * @param {string} url WebSocket endpoint of the KB.
     * @param {string} token Authentication token.
     * @param {*} [options] Optional options to be passed to the `WebSocket` constructor.
     */
    static connect(url, token, options) {
        const ws = new WebSocket(url, options);
        return new Promise((resolve, reject) => {
            const onopen = () => {
                ws.removeListener('error', onerror);
                resolve(new KBClient(ws, token));
            };

            const onerror = e => {
                ws.removeListener('open', onopen);
                reject(e);
            };

            ws.once('open', onopen);
            ws.once('error', onerror);
        });
    }

    /**
     * Asynchronously invokes a remote method on the KB.
     * 
     * @param {string} method Remote method name.
     * @param {*} [params] Method parameters.
     */
    invoke(method, params) {
        
        const d = new Deferred();
        this._pendingRequests.push(d);

        // Sends the request
        this._ws.send(JSON.stringify({
            method,
            params,
            token: this._token
        }), e => {
            if (e) {
                d.reject(e);
                this._pendingRequests.pop();
            } else {
                debug('Request sent. Method: %s, params: %o.', method, params);
            }
        });

        return d.promise;
    }

    _onMessage(message) {
        const d = this._pendingRequests.pop();

        // Parse the message from the server
        let m;
        try {
            m = JSON.parse(message);
        } catch (e) {
            d.reject(e);
            return;
        }

        debug('Response from server: %o', m);
        
        if (m.success) {
            d.resolve(m.details);
        } else {
            d.reject(new Error('KB error: ' + m.details));
        }
    }

    _onError(e) {
        debug('Connection terminated: %o', e);

        e = e || new Error('Underlying connection terminated.');
        this._pendingRequests.forEach(req => req.reject(e));
        this._pendingRequests = [];
    }

};