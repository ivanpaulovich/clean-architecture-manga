import axios from "axios";

const api = axios.create({
    headers: {
      'Content-Type': 'application/json'
    },
    baseURL: `${process.env.REACT_APP_ACCOUNTS_API}`
  });

api.interceptors.request.use(
    function (config) {
      const oidcStorage = JSON.parse(
        window.sessionStorage.getItem(
          `oidc.user:${process.env.REACT_APP_AUTH_URL}:${process.env.REACT_APP_IDENTITY_CLIENT_ID}`
        )
      );
  
      if (!!oidcStorage && !!oidcStorage.access_token) {
        config.headers.Authorization = `Bearer ${oidcStorage.access_token}`;
      }
  
      return config;
    },
    function (err) {
      return Promise.reject(err);
    }
  );

export default api;
