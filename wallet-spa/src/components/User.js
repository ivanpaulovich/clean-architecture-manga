import React, { PureComponent, useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import React from 'react';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import AccountCircle from '@material-ui/icons/AccountCircle';
import ExitToApp from '@material-ui/icons/ExitToApp';
import { makeStyles } from '@material-ui/core/styles';
import { Avatar } from '@material-ui/core';
import { Grid } from '@material-ui/core';

const drawerWidth = 240;

const useStyles = makeStyles(theme => ({
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    backgroundImage: `linear-gradient(#cfd9df,#e2ebf0)`,
    color: 'grey',
  },
  bigAvatar: {
    margin: 30,
    width: 100,
    height: 100,
  },
}));
export const User = (props) => {
  const config = {
    authority: process.env.REACT_APP_AUTHORITY,
    client_id: "spa",
    redirect_uri: process.env.REACT_APP_REDIRECT_URI,
    response_type: "code",
    scope: "openid profile api1.full_access",
    post_logout_redirect_uri: process.env.REACT_APP_POST_LOGOUT_REDIRECT_URI,
  };

  const openIdManager = new Oidc.UserManager(config);

  const currentUserState = {
    isLoggedIn: false,
    user: null,
  };
  const [currentUser, setCurrentUser] = useState(currentUserState);

  const classes = useStyles();

  const getUser = () => {
    openIdManager.getUser().then((user) => {
      if (user) {
        setCurrentUser({
          isLoggedIn: true,
          user: user
        });
      } else {
        setCurrentUser({
          isLoggedIn: false,
          user: null
        });
      }
    });
  };

  useEffect(() => {
    getUser();
  });

  return (
    <Drawer
        open={true}
        variant='permanent'
        anchor='left'
        className={classes.drawer}
        classes={{
          paper: classes.drawerPaper,
        }}
      >
        <Grid container justify='center' alignItems='center'>
          <Avatar
            src='https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg'
            className={classes.bigAvatar}
          />
        </Grid>
        <List>
          {!currentUserState.isLoggedIn && 
            <ListItem>
              <ListItemIcon>
                <AccountCircle />
              </ListItemIcon>
              <ListItemText primary="Login" onClick={openIdManager.signinRedirect()}/>
            </ListItem>
          }
          {currentUserState.isLoggedIn && 
            <ListItem>
              <ListItemIcon>
                <ExitToApp />
              </ListItemIcon>
              <ListItemText primary="Logout" onClick={openIdManager.signoutRedirect()}/>
            </ListItem>
          }
        </List>
      </Drawer>
  );
};
