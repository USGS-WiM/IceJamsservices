## Damage type batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload Damage type resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/Damagetypes/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"Damage typeSample 1",
    "description":"Description of Damage type Sample 1"
},
{
    "name":"Damage typeSample 2",
    "description":"Description of Damage type Sample 2"
},
{
    "name":"Damage typeSample 3",
    "description":"Description of Damage type Sample 3"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"Damage typeSample 1",
    "description":"Description of Damage type Sample 1"
},
{
	"id":52,
    "name":"Damage typeSample 2",
    "description":"Description of Damage type Sample 2"
},
{
	"id":53,
    "name":"Damage typeSample 3",
    "description":"Description of Damage type Sample 3"
}]
```