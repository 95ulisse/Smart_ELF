Command Line Interface (cli)

***DEPRECATED***



register

      Registers a new user to the system. It is mandatory to
      perform any store operation.

store <idSource> <infoSum> <json>

      <idSource>: the id of the user of the KB, retrieved using
                  register command.
      <infoSum>:  a string
      <json>:     a string containing a json.
                  Use single apex to delimit the whole string and
                  double apex to delimit name on keys/values.

      Perform a store operation on the KB. It is succesful only
      if the idSource was registered before.

delete <idSource> <json>

       Perform a delete operation on the KB.

query <json>

      Perform a query opration


monitor <action> <args...>

      Repeat every 3 seconds the <action> using the <args...>

Usage example:

```bash
$ ./cli/register
proto1

$ ./cli/store 'proto1' 'RDF' '{"subject":"dog", "relation":"is a", "object":"animal"}'
done

$ ./cli/store 'proto1' 'RDF' '{"subject":"cat", "relation":"is a", "object":"animal"}'
done

$ ./cli/query '{"subject":"$s", "object":"animal"}'
[
{'_data': {'subject': 'dog', 'relation': 'is a', 'object': 'animal'}, '_id': 1, '_infoSum': 'RDF', '_reliability': 100, '_source': 'proto1', '_ttl': 1},
{'_data': {'subject': 'cat', 'relation': 'is a', 'object': 'animal'}, '_id': 2, '_infoSum': 'RDF', '_reliability': 100, '_source': 'proto1', '_ttl': 1}
]

$ ./cli/delete 'proto1' '{"subject":"$s", "object":"animal"}'
done

$ ./cli/query '{"subject":"$s", "object":"animal"}'
[]
```