import React, { PureComponent } from 'react';
import * as Oidc from "oidc-client";
import { Redirect } from "react-router-dom";

export class AuthCallback extends PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            redirect: false
        }
    }

    componentDidMount() {
        new Oidc.UserManager({ response_mode: "query" })
            .signinRedirectCallback()
            .then(() => {
                this.setState({ redirect: true })
            }).catch(function (e) {
                console.error(e);
            });
    }

    render() {
        if (this.state.redirect) {
            return (<Redirect to="/" push />)
        }

        return (<div>Redirecting...</div>)
    }
}
