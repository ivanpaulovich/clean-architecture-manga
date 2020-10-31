import React, { Component } from "react";
import Drawer from "@material-ui/core/Drawer";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import ExitToApp from "@material-ui/icons/ExitToApp";
import AddIcon from '@material-ui/icons/Add';
import { Avatar } from "@material-ui/core";
import { withStyles } from "@material-ui/core/styles";
import classNames from "classnames";
import { fade } from "@material-ui/core/styles/colorManipulator";
import { AuthConsumer } from "../providers/authProvider"
import AuthService from "../store/authService";

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

  authService;

  constructor(props) {
    super(props);

    this.state = {
      user: {
        profile: {
          name: ""
        }
      }
    }

    this.authService = new AuthService();
  }

  componentDidMount() {
    this.authService
      .getUser()
      .then((user) => {
        this.setState({ user: user });
      });
  }

  render() {
    const { classes, navDrawerOpen } = this.props;
    return (
      <div>
        <Drawer
          open={navDrawerOpen}
          variant="permanent"
          classes={{
            paper: classNames(classes.drawerPaper, !navDrawerOpen && classes.drawerPaperClose)
          }} >
          <div>
            <div className={classes.logo}>My Wallet</div>
            <div className={classNames(classes.avatarRoot, !navDrawerOpen && classes.avatarRootMini)}>
              <Avatar size={navDrawerOpen ? 48 : 32} classes={{ root: classes.avatarIcon }} />
              <span className={classes.avatarSpan}>{this.state.user.profile.name}</span>
            </div>
            <List>
              <ListItem button component="a" href="/Dashboard">
                <ListItemIcon style={{ color: "white" }}>
                  <AccountBalanceIcon />
                </ListItemIcon>
                <ListItemText primary="My Accounts" />
              </ListItem>
              <ListItem button component="a" href="/Dashboard/OpenAccount">
                <ListItemIcon style={{ color: "white" }}>
                  <AddIcon />
                </ListItemIcon>
                <ListItemText primary="Open an Account" />
              </ListItem>
              <ListItem button>
                <ListItemIcon style={{ color: "white" }}>
                  <ExitToApp />
                </ListItemIcon>
                <AuthConsumer>
                  {({ logout }) => {
                    return (
                      <ListItemText primary="Sign Out" onClick={logout} />
                    );
                  }}
                </AuthConsumer>
              </ListItem>
            </List>
          </div>

        </Drawer>
      </div>
    );
  }
}

export default withStyles(drawStyles, { withTheme: true })(SideMenu);