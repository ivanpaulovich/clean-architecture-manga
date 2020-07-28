import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import * as serviceWorker from './serviceWorker';
import * as Oidc from "oidc-client";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const config = {
    authority: "https://localhost:5000",
    client_id: "spa",
    redirect_uri: "https://localhost:5010/callback",
    response_type: "code",
    scope: "openid profile api1.full_access",
    post_logout_redirect_uri: "https://localhost:5010",
};

const openIdManager = new Oidc.UserManager(config);

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <App openIdManager={openIdManager} />
    </BrowserRouter>,
    rootElement);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
