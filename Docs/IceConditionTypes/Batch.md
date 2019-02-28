## IceConditionType batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload Ice condition type resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/iceconditiontypes/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"Ice condition typeSample 1",
    "description":"Description of Ice condition type Sample 1"
},
{
    "name":"Ice condition typeSample 2",
    "description":"Description of Ice condition type Sample 2"
},
{
    "name":"Ice condition typeSample 3",
    "description":"Description of Ice condition type Sample 3"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"Ice condition typeSample 1",
    "description":"Description of Ice condition type Sample 1"
},
{
	"id":52,
    "name":"Ice condition typeSample 2",
    "description":"Description of Ice condition type Sample 2"
},
{
	"id":53,
    "name":"Ice condition typeSample 3",
    "description":"Description of Ice condition type Sample 3"
}]
```