# Authentication

```js
POST {{host}}/auth/register
```
### Register Request
```json
{
	"firstName":"Saidul Islam",
	"lastName":"Rajib",
	"email":"saidul.is.rajib@gmail.com"
	"password":"Test@123"
}
```

### Register Response
```json
{
	"id":"00000000-0000-0000-0000-000000000000",
	"firstName":"Saidul Islam",
	"lastName":"Rajib",
	"email":"saidul.is.rajib@gmail.com"
	"token":"bearertoken...."
}
```



```js
POST {{host}}/auth/login
```
### Login Request
```json
{
	"email":"saidul.is.rajib@gmail.com"
	"password":"Test@123"
}
```

### Login Response
```json
{
	"id":"00000000-0000-0000-0000-000000000000",
	"firstName":"Saidul Islam",
	"lastName":"Rajib",
	"email":"saidul.is.rajib@gmail.com"
	"token":"bearertoken...."
}
```
