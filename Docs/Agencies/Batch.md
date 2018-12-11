## Agency batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload Agency resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/agency/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
    "name":"AgencySample 1",
    "description":"Description of Agency Sample 1",
    "abbreviation":"Uniqueabbr1"
},
{
    "name":"AgencySample 2",
    "description":"Description of Agency Sample 2",
    "abbreviation":"Uniqueabbr2"
},
{
    "name":"AgencySample 3",
    "description":"Description of Agency Sample 3",
    "abbreviation":"Uniqueabbr3"
}]
```

```
HTTP/1.1 200 OK
[{
	"id":51,
    "name":"AgencySample 1",
    "description":"Description of Agency Sample 1",
    "abbreviation":"Uniqueabbr1"
},
{
	"id":52,
    "name":"AgencySample 2",
    "description":"Description of Agency Sample 2",
    "abbreviation":"Uniqueabbr2"
},
{
	"id":53,
    "name":"AgencySample 3",
    "description":"Description of Agency Sample 3",
    "abbreviation":"Uniqueabbr3"
}]
```