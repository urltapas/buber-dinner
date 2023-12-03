# Buber Dinner API
- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request
```json
{
    "firstName": "FirstName",
    "lastName": "LastName",
    "email": "user.one@email.com",
    "password": "senhasenha"
}
```

#### Register Response
```js
200 OK
```

```json
{
    "id": "2e54106f-4be0-4b69-987a-8e37a8bcf10d",
    "firstName": "FirstName",
    "lastName": "LastName",
    "email": "user.one@email.com",
    "token":"asdfwe...2sfasw"
}
```