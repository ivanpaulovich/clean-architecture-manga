import { createTheme } from "@material-ui/core/styles";
import { blue, grey, pink, red, deepOrange, orange, teal, green, amber, lime, purple } from "@material-ui/core/colors";

export const availableThemes = [
  {
    title: "Default",
    primary: blue,
    secondary: pink
  },
  {
    title: "Sunset",
    primary: deepOrange,
    secondary: orange
  },
  {
    title: "Greeny",
    primary: teal,
    secondary: green
  },
  {
    title: "Beach",
    primary: grey,
    secondary: amber
  },
  {
    title: "Tech",
    primary: blue,
    secondary: lime
  },
  {
    title: "Deep Ocean",
    primary: purple,
    secondary: pink
  }
];

const defaultTheme = {
  palette: {
    primary: blue,
    secondary: pink
  },
  error: red,
  appBar: {
    height: 57,
    color: blue[600]
  },
  drawer: {
    width: 240,
    color: grey[900],
    backgroundColor: grey[900],
    miniWidth: 56
  },
  raisedButton: {
    primaryColor: blue[600]
  },
  typography: {
    // useNextVariants: true
  }
};

const theme = createTheme(defaultTheme);

export const customTheme = option => {
  return createTheme({ ...defaultTheme, ...option });
};

export default theme;