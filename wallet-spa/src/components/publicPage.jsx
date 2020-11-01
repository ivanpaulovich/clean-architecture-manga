
import React from "react";
import {
  Button,
  Grid,
  Paper,
  AppBar,
  Typography,
  Toolbar,
} from "@material-ui/core";
import { AuthConsumer } from "../providers/authProvider"

export const PublicPage = () => (
  <div>
    <AppBar position="static" alignitems="center" color="primary">
      <Toolbar>
        <Grid container justify="center" wrap="wrap">
          <Grid item>
            <Typography variant="h6">Clean Architecture Manga</Typography>
          </Grid>
        </Grid>
      </Toolbar>
    </AppBar>
    <Grid container spacing={0} justify="center" direction="row">
      <Grid item>
        <Grid
          container
          direction="column"
          justify="center"
          spacing={2}
          className="login-form"
        >
          <Paper
            variant="elevation"
            elevation={2}
            className="login-background"
          >
            <Grid item>
              <AuthConsumer>
                {({ signinRedirect }) => {
                  return <Button variant="contained" color="primary" type="submit" className="button-block" onClick={signinRedirect}>Sign In</Button>;
                }}
              </AuthConsumer>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </Grid>
  </div>
);




