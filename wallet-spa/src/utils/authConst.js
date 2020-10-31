export const IDENTITY_CONFIG = {
  authority: process.env.REACT_APP_AUTH_URL,
  client_id: process.env.REACT_APP_IDENTITY_CLIENT_ID,
  redirect_uri: process.env.REACT_APP_REDIRECT_URL,
  silent_redirect_uri: process.env.REACT_APP_SILENT_REDIRECT_URL,
  post_logout_redirect_uri: process.env.REACT_APP_LOGOFF_REDIRECT_URL,
  audience: process.env.REACT_APP_AUDIENCE,
  response_type: "code",
  response_mode: "query",
  automaticSilentRenew: false,
  loadUserInfo: true,
  scope: "openid profile api1.full_access",
};

export const METADATA_OIDC = {
  issuer: process.env.REACT_APP_ISSUER,
  jwks_uri: process.env.REACT_APP_AUTH_URL + "/.well-known/openid-configuration/jwks",
  authorization_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/authorize",
  token_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/token",
  userinfo_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/userinfo",
  end_session_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/endsession",
  check_session_iframe: process.env.REACT_APP_AUTH_URL + "/connect/checksession",
  revocation_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/revocation",
  introspection_endpoint: process.env.REACT_APP_AUTH_URL + "/connect/introspect",
};



// {
//   "issuer":"https://localhost:5000",
//   "jwks_uri":"https://localhost:5000/.well-known/openid-configuration/jwks",
//   "authorization_endpoint":"https://localhost:5000/connect/authorize",
//   "token_endpoint":"https://localhost:5000/connect/token",
//   "userinfo_endpoint":"https://localhost:5000/connect/userinfo",
//   "end_session_endpoint":"https://localhost:5000/connect/endsession",
//   "check_session_iframe":"https://localhost:5000/connect/checksession",
//   "revocation_endpoint":"https://localhost:5000/connect/revocation",
//   "introspection_endpoint":"https://localhost:5000/connect/introspect",
//   "device_authorization_endpoint":"https://localhost:5000/connect/deviceauthorization",
//   "frontchannel_logout_supported":true,
//   "frontchannel_logout_session_supported":true,
//   "backchannel_logout_supported":true,
//   "backchannel_logout_session_supported":true,
//   "scopes_supported":[
//      "openid",
//      "profile",
//      "api1.read_only",
//      "api1.full_access",
//      "offline_access"
//   ],
//   "claims_supported":[
//      "sub",
//      "name",
//      "family_name",
//      "given_name",
//      "middle_name",
//      "nickname",
//      "preferred_username",
//      "profile",
//      "picture",
//      "website",
//      "gender",
//      "birthdate",
//      "zoneinfo",
//      "locale",
//      "updated_at"
//   ],
//   "grant_types_supported":[
//      "authorization_code",
//      "client_credentials",
//      "refresh_token",
//      "implicit",
//      "password",
//      "urn:ietf:params:oauth:grant-type:device_code"
//   ],
//   "response_types_supported":[
//      "code",
//      "token",
//      "id_token",
//      "id_token token",
//      "code id_token",
//      "code token",
//      "code id_token token"
//   ],
//   "response_modes_supported":[
//      "form_post",
//      "query",
//      "fragment"
//   ],
//   "token_endpoint_auth_methods_supported":[
//      "client_secret_basic",
//      "client_secret_post"
//   ],
//   "id_token_signing_alg_values_supported":[
//      "RS256"
//   ],
//   "subject_types_supported":[
//      "public"
//   ],
//   "code_challenge_methods_supported":[
//      "plain",
//      "S256"
//   ],
//   "request_parameter_supported":true
// }