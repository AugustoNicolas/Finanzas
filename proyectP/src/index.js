import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

import { HashRouter as Router, Route, Switch } from 'react-router-dom';

import Registro from './componentes/registro/Registro';
import Login from './componentes/login/Login';
import Inicio from './componentes/inicio/Inicio';
import Nosotros from './componentes/nosotros/Nosotros';
import Servicios from './componentes/servicios/Servicios';
import Contacto from './componentes/contacto/Contacto';

import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../node_modules/bootstrap/dist/js/bootstrap.min.js'

ReactDOM.render(
  /*ReactDOM.render(
    <React.StrictMode>
      <Login />
    </React.StrictMode>,
    document.getElementById('root')*/
  <React.StrictMode>
    <Router>
      <div>
        <Switch>
          <Route exact path='/' component={Login} />
          <Route path='/registro' component={Registro} />
          <Route path='/inicio' component={Inicio} />
          <Route path='/nosotros' component={Nosotros} />
          <Route path='/servicios' component={Servicios} />
          <Route path='/contacto' component={Contacto} />
        </Switch>

      </div>
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
