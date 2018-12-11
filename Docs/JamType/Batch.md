## JamType batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload JamType resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/JamType/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"JamTypeSample 1",
    "description":"Description of JamType Sample 1",
    "exampleimageurl":"/somesampleimage1.png"
},
{
    "name":"JamTypeSample 2",
    "description":"Description of JamType Sample 2",
    "exampleimageurl":"/somesampleimage2.png"
},
{
    "name":"JamTypeSample 3",
    "description":"Description of JamType Sample 3",
    "exampleimageurl":"/somesampleimage3.png"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"JamTypeSample 1",
    "description":"Description of JamType Sample 1",
    "exampleimageurl":"/somesampleimage1.png"
},
{
	"id":52,
    "name":"JamTypeSample 2",
    "description":"Description of JamType Sample 2",
    "exampleimageurl":"/somesampleimage2.png"
},
{
	"id":53,
    "name":"JamTypeSample 3",
    "description":"Description of JamType Sample 3",
    "exampleimageurl":"/somesampleimage3.png"
}]
```