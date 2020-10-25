import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/styles';
import Header from "./Header";
import SideMenu from "../components/SideMenu";
import Footer from "../components/Footer";
import MainContent from "../components/MainContent";
import { ThemeProvider } from "@material-ui/core/styles";
import defaultTheme from "../theme";
import classNames from "classnames";

const styles = () => ({
  container: {
    margin: "80px 20px 20px 15px",
    paddingLeft: defaultTheme.drawer.width,
    [defaultTheme.breakpoints.down("sm")]: {
      paddingLeft: 0
    }
  },
  containerFull: {
    paddingLeft: defaultTheme.drawer.miniWidth,
    [defaultTheme.breakpoints.down("sm")]: {
      paddingLeft: 0
    }
  },
  settingBtn: {
    top: 80,
    backgroundColor: "rgba(0, 0, 0, 0.3)",
    color: "white",
    width: 48,
    right: 0,
    height: 48,
    opacity: 0.9,
    padding: 0,
    zIndex: 999,
    position: "fixed",
    minWidth: 48,
    borderTopRightRadius: 0,
    borderBottomRightRadius: 0
  }
});

class Layout extends React.Component {
  static displayName = Layout.name;
  constructor(props) {
    super(props);

    this.state = {
      theme: defaultTheme,
      rightDrawerOpen: false,
      navDrawerOpen:
        window && window.innerWidth && window.innerWidth >= defaultTheme.breakpoints.values.md
          ? true
          : false
    };

    this.handleChangeNavDrawer = this.handleChangeNavDrawer.bind(this);
  }

  handleChangeNavDrawer() {
    this.setState({
      navDrawerOpen: !this.state.navDrawerOpen
    });
  }

  render() {
    const { classes } = this.props;
    const { navDrawerOpen, theme } = this.state;
    return (
      <ThemeProvider theme={theme}>
        <Header handleChangeNavDrawer={this.handleChangeNavDrawer} navDrawerOpen={navDrawerOpen} />
        <SideMenu navDrawerOpen={navDrawerOpen} handleChangeNavDrawer={this.handleChangeNavDrawer} />
        <div className={classNames(classes.container, !navDrawerOpen && classes.containerFull)}>
          <MainContent />
        </div>
        <Footer />
      </ThemeProvider>
    );
  }
}

Layout.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Layout);