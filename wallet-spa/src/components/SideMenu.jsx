import React, { Component } from "react";
import Drawer from "@material-ui/core/Drawer";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import AccountCircle from "@material-ui/icons/AccountCircle";
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import ExitToApp from "@material-ui/icons/ExitToApp";
import AddIcon from '@material-ui/icons/Add';
import { Avatar } from "@material-ui/core";
import { withStyles } from "@material-ui/core/styles";
import classNames from "classnames";
import { fade } from "@material-ui/core/styles/colorManipulator";
import { userContext } from '../userContext';

const drawStyles = theme => {
  return {
    drawerPaper: {
      width: theme.drawer.width,
      backgroundColor: "rgb(33, 33, 33)",
      color: "white",
      borderRight: "0px",
      boxShadow: "rgba(0, 0, 0, 0.16) 0px 3px 10px, rgba(0, 0, 0, 0.23) 0px 3px 10px"
    },
    drawerPaperClose: {
      overflowX: "hidden",
      transition: theme.transitions.create("width", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
      }),
      width: theme.drawer.miniWidth
    },
    logo: {
      cursor: "pointer",
      fontSize: 22,
      color: "white",
      lineHeight: "64px",
      fontWeight: 300,
      backgroundColor: theme.palette.primary[500],
      paddingLeft: 40,
      height: 64
    },
    avatarRoot: {
      padding: "16px 0 10px 15px",
      backgroundImage: "url(" + require("../images/material_bg.png") + ")",
      height: 100,
      display: "flex"
    },
    avatarRootMini: {
      padding: "15px 0 10px 10px"
    },
    avatarIcon: {
      float: "left",
      display: "block",
      boxShadow: "0px 0px 0px 8px rgba(0,0,0,0.2)"
    },
    avatarSpan: {
      paddingTop: 8,
      paddingLeft: 24,
      display: "block",
      color: "white",
      fontWeight: 300,
      textShadow: "1px 1px #444"
    },
    menuItem: {
      color: "white",
      fontSize: 14
    },
    chevronIcon: {
      float: "right",
      marginLeft: "auto"
    },
    subMenus: {
      paddingLeft: 20
    },
    popupSubMenus: {
      backgroundColor: "rgb(33, 33, 33)",
      color: "white",
      boxShadow: "rgba(0, 0, 0, 0.16) 0px 3px 10px, rgba(0, 0, 0, 0.23) 0px 3px 10px"
    },
    menuItem: {
      padding: "10px 16px",
      color: "white",
      fontSize: 14,
      "&:focus": {
        backgroundColor: theme.palette.primary.main,
        "& .MuiListItemIcon-root, & .MuiListItemText-primary": {
          color: theme.palette.common.white
        }
      }
    },
    miniMenuItem: {
      color: "white",
      margin: "10px 0",
      fontSize: 14,
      "&:focus": {
        backgroundColor: theme.palette.primary.main,
        "& .MuiListItemIcon-root, & .MuiListItemText-primary": {
          color: theme.palette.common.white
        }
      }
    },
    miniIcon: {
      margin: "0 auto",
      color: "white",
      "&:hover": {
        backgroundColor: fade(theme.palette.common.white, 0.5)
      },
      minWidth: "24px"
    }
  };
};

class SideMenu extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { classes, navDrawerOpen, handleChangeNavDrawer } = this.props;
    return (
      <div>
        <Drawer
          open={navDrawerOpen}
          variant="permanent"
          classes={{
            paper: classNames(classes.drawerPaper, !navDrawerOpen && classes.drawerPaperClose)
          }}
        >

          <userContext.Consumer>
            {({ user, loginUser, logoutUser }) => {
              return (
                <div>
                  <div className={classes.logo}>My Wallet</div>
                  {Object.keys(user).length !== 0 && <div className={classNames(classes.avatarRoot, !navDrawerOpen && classes.avatarRootMini)}>
                    <Avatar size={navDrawerOpen ? 48 : 32} classes={{ root: classes.avatarIcon }} />
                    <span className={classes.avatarSpan}>{user.profile.name}</span>
                  </div>}
                  <List>
                    {Object.keys(user).length !== 0 ? this.renderWhenTrue(logoutUser) : this.renderWhenFalse(loginUser)}
                  </List>
                </div>
              );
            }}
          </userContext.Consumer>
        </Drawer>
      </div>
    );
  }

  renderWhenTrue(logoutUser) {
    return (
      <React.Fragment>
        <ListItem button component="a" href="/">
          <ListItemIcon style={{ color: "white" }}>
            <AccountBalanceIcon />
          </ListItemIcon>
          <ListItemText primary="My Accounts" />
        </ListItem>
        <ListItem button component="a" href="/OpenAccount">
          <ListItemIcon style={{ color: "white" }}>
            <AddIcon />
          </ListItemIcon>
          <ListItemText primary="Open an Account" />
        </ListItem>
        <ListItem button>
          <ListItemIcon style={{ color: "white" }}>
            <ExitToApp />
          </ListItemIcon>
          <ListItemText primary="Sign Out" onClick={logoutUser} />
        </ListItem>
      </React.Fragment>
    )
  }

  renderWhenFalse(loginUser) {
    return (
      <React.Fragment>
        <ListItem button>
          <ListItemIcon style={{ color: "white" }}>
            <AccountCircle />
          </ListItemIcon>
          <ListItemText primary="Sign In" onClick={loginUser} />
        </ListItem>
      </React.Fragment>
    )
  }
}

export default withStyles(drawStyles, { withTheme: true })(SideMenu);