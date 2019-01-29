## Site batch upload
<span style="color:red">Requires Administrators Authentication</span>   
Provides the ability to batch upload site resources.

#### Request Example
The REST URL section below displays the example url and the body/payload of the request used to simulate a response.

```
POST /icejamsservices/sites/batch HTTP/1.1
Host: wim.usgs.gov
Accept: application/json
content-type: application/json;charset=UTF-8
content-length: 576

[{
	"name":"Mississippi River at St. Louis, MO",
	"location":{"type":"Point","coordinates":[-90.16805555,38.6175]},
	"state":"MO",
	"county":"St. Louis City",
	"riverName":"Mississipppi River",
	"huc":"7140101",
	"usgsid":"07010000"
 },
 {
	"name":"Susquehanna River near McCalls Ferry, PA",
	"location":{"type":"Point","coordinates":[-75.59583333,41.97138888]},
	"state":"PA",
	"county":"Susquehanna",
	"riverName":"Susquehanna River",
	"huc":"02050306",
	"usgsid":"01577000"
 },
 {
	"name":"Oil Creek",
	"location":{"type":"Point","coordinates":[-79.70416666,41.42638888]},
	"state":"PA",
	"county":"Venango",
	"riverName":"Oil Creek",
	"huc":"05010003"
 },
 {
	"name":"Buffalo Creek near Boggsville",
	"location":{"type":"Point","coordinates":[-79.67036111,40.75955555]},
	"state":"PA",
	"county":"Armstrong",
	"riverName":"Buffalo Creek",
	"huc":"Null",
	"usgsid":"03049000",
	"ahpsid":"FRPP1"
 },
 {
	"name":"Buffalo Creek near Boggsville",
	"location":{"type":"Point","coordinates":[-85.45361111,40.7125]},
	"state":"IN",
	"county":"Huntington",
	"riverName":"Salamonie River",
	"huc":"Null",
	"usgsid":"03224300",
	"ahpsid":"WRNI3"
 }]
```

```
HTTP/1.1 200 OK
[{
	"id":1,
	"name":"Mississippi River at St. Louis, MO",
	"location":{"type":"Point","coordinates":[-90.16805555,38.6175]},
	"state":"MO",
	"county":"St. Louis City",
	"riverName":"Mississipppi River",
	"huc":"7140101",
	"usgsid":"07010000"
 },
 {
    "id":2,
	"name":"Susquehanna River near McCalls Ferry, PA",
	"location":{"type":"Point","coordinates":[-75.59583333,41.97138888]},
	"state":"PA",
	"county":"Susquehanna",
	"riverName":"Susquehanna River",
	"huc":"02050306",
	"usgsid":"01577000"
 },
 {
	"id":3,
	"name":"Oil Creek",
	"location":{"type":"Point","coordinates":[-79.70416666,41.42638888]},
	"state":"PA",
	"county":"Venango",
	"riverName":"Oil Creek",
	"huc":"05010003"
 },
 {
	"id":4,
	"name":"Buffalo Creek near Boggsville",
	"location":{"type":"Point","coordinates":[-79.67036111,40.75955555]},
	"state":"PA",
	"county":"Armstrong",
	"riverName":"Buffalo Creek",
	"huc":"Null",
	"usgsid":"03049000",
	"ahpsid":"FRPP1"
 },
 {
	"id":5,
	"name":"Buffalo Creek near Boggsville",
	"location":{"type":"Point","coordinates":[-85.45361111,40.7125]},
	"state":"IN",
	"county":"Huntington",
	"riverName":"Salamonie River",
	"huc":"Null",
	"usgsid":"03224300",
	"ahpsid":"WRNI3"
 }]
```