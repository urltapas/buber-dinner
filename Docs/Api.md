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
    "firstName": "New",
    "lastName": "User",
    "email": "new.user@email.com",
    "password": "newuser"
}
```

#### Register Response
```js
200 OK
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "fristName": "New",
  "lastName": "User",
  "email": "new.user@email.com",
  "token": "eyJhbGciOiJ...hTdMNSwXDKD3M"
}
```