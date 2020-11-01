import * as React from "react";
import { AuthConsumer } from "../../providers/authProvider";

export const Logout = () => (
    <AuthConsumer>
        {({ logout }) => {
            logout();
            return <span>loading</span>;
        }}
    </AuthConsumer>
);