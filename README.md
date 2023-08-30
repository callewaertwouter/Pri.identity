# Postman

POST to https://localhost:7028/Identity/Account/Login

RAW Body (JSON):

{
    "email": "test@test.com",
    "password": "Test123?",
    "rememberme": true
}

ERROR: 400 Bad Request
"Unable to verify the first certificate"
authorizationError: "UNABLE_TO_VERIFY_LEAF_SIGNATURE"

Why is Postman so utter shit at handling certificates for a bloody LOCALHOST?!?!
