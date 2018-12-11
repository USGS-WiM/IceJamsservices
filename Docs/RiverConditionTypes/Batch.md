## RiverConditionType batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload river condition type resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/riverconditiontypes/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"river condition typeSample 1",
    "description":"Description of river condition type Sample 1"
},
{
    "name":"river condition typeSample 2",
    "description":"Description of river condition type Sample 2"
},
{
    "name":"river condition typeSample 3",
    "description":"Description of river condition type Sample 3"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"river condition typeSample 1",
    "description":"Description of river condition type Sample 1"
},
{
	"id":52,
    "name":"river condition typeSample 2",
    "description":"Description of river condition type Sample 2"
},
{
	"id":53,
    "name":"river condition typeSample 3",
    "description":"Description of river condition type Sample 3"
}]
```