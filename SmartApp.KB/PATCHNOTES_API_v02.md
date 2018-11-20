API VERSION 0.2



# Register update
 `register` became `registerTags`: now you have to provide a list of tags to register to the kb. 

 **IMPORTANT**:
your module won't be able to register if ANY of the tag you provide had already been provided by some other module. Your module won't be able to add facts if its tag wasn't registered



# Query update
`query` now requires a json with at least one of the following properties

```json
{
_data : {"your data written in a json format"}
_meta : {"look at the documentation"}
_id   : yourId
}
```    
    
Practically what you put in the query so far now goes in _data

Note that you can query only the id if you want an exact lookup



# Python Bindings changed
The methods to communicate with the kb have been gathered in a class *KnowledgeBaseClient*


The constructor requires a boolean parameter to specify whether the connection has to be kept persistent



# Return types
Now the server functions return the result within an object consisting of the following properties:
```json
{
    succes : boolean
    details : any
}
```
Type of details property depends on the function called. For more info consult the documentation provided by *kbman*

