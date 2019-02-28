## File type batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload File type resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/Filetypes/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"File typeSample 1",
    "description":"Description of File type Sample 1"
},
{
    "name":"File typeSample 2",
    "description":"Description of File type Sample 2"
},
{
    "name":"File typeSample 3",
    "description":"Description of File type Sample 3"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"File typeSample 1",
    "description":"Description of File type Sample 1"
},
{
	"id":52,
    "name":"File typeSample 2",
    "description":"Description of File type Sample 2"
},
{
	"id":53,
    "name":"File typeSample 3",
    "description":"Description of File type Sample 3"
}]
```