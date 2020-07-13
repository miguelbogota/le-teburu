import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import { ThemeProvider } from "@material-ui/core/styles";
import theme from "./ConfigTheme";
// Componentes
import Toolbar from "./components/Navigation";
// Vistas
import HomePage from "./views/HomePage";

const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Toolbar />
        <Route path="/" component={HomePage} exact />
      </Router>
    </ThemeProvider>
  );
};

export default App;
