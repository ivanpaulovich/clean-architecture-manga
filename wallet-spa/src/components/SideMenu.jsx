import React, { Component } from "react";
import Drawer from "@material-ui/core/Drawer";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import AccountCircle from "@material-ui/icons/AccountCircle";
import ExitToApp from "@material-ui/icons/ExitToApp";
import { Avatar } from "@material-ui/core";
import { Grid } from "@material-ui/core";
import { withStyles } from "@material-ui/core/styles";

const drawerWidth = 240;

const styles = theme => ({
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    backgroundImage: `linear-gradient(#cfd9df,#e2ebf0)`,
    color: "grey",
  },
  bigAvatar: {
    margin: 30,
    width: 100,
    height: 100,
  },
});

class SideMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoggedIn: false,
      user: null
    }

    this.performLogin = this.performLogin.bind(this);
    this.performLogout = this.performLogout.bind(this);
  }

  componentDidMount() {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        this.setState({ isLoggedIn: true, user: user });
      } else {
        this.setState({ isLoggedIn: false, user: null });
      }
    });
  }

  render() {
    const { classes } = this.props;
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
        { this.state.isLoggedIn ? this.renderWhenTrue() : this.renderWhenFalse()}
      </Drawer>
    );
  }

  renderWhenTrue() {
    return (
      <List>
        <ListItem button>
          <ListItemIcon>
            <AccountCircle />
          </ListItemIcon>
          <ListItemText primary={this.state.user.profile.name} />
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <ExitToApp />
          </ListItemIcon>
          <ListItemText primary="Sign Out" onClick={this.performLogout} />
        </ListItem>
      </List>
    )
  }

  renderWhenFalse() {
    return (
      <List>
        <ListItem button>
          <ListItemIcon>
            <AccountCircle />
          </ListItemIcon>
          <ListItemText primary="Sign In" onClick={this.performLogin} />
        </ListItem>
      </List>
    )
  }

  performLogin() {
    this.props.openIdManager.signinRedirect();
  }

  performLogout() {
    this.props.openIdManager.signoutRedirect();
  }
}

export default withStyles(styles, { withTheme: true })(SideMenu);