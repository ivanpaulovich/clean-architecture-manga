
import React from 'react';
import Button from "@material-ui/core/Button";
import { AuthConsumer } from "../providers/authProvider"

export const PublicPage = () => (
    <AuthConsumer>
        {({ signinRedirect }) => {
            return <Button color="primary" onClick={signinRedirect}>Sign In</Button>;
        }}
    </AuthConsumer>
);