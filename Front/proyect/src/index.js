import React from 'react';
import ReactDOM  from 'react-dom/client';
import './index.css';
import App from './App';

import reportWebVitals from './reportWebVitals';

import { HashRouter as Router, Route, Routes } from 'react-router-dom';

import Registro from './componentes/registro/Registro';
import Login from './componentes/login/Login';
import Inicio from './componentes/inicio/Inicio';
import Nosotros from './componentes/nosotros/Nosotros';
import Servicios from './componentes/servicios/Servicios';
import Contacto from './componentes/contacto/Contacto';
import Stats from './componentes/stats/Stats';
import Categoria from './componentes/categoria/Categoria';

import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../node_modules/bootstrap/dist/js/bootstrap.min.js'

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(  
  <React.StrictMode>
    <Router>
      <div>
        <Routes>
          <Route exact path='/' element={<Inicio/>}/>
          <Route path='/registro' element={<Registro/>} />
          <Route path='/login' element={<Login/>} />
          <Route path='/nosotros' element={<Nosotros/>} />
          <Route path='/servicios' element={<Servicios/>} />
          <Route path='/contacto' element={<Contacto/>} />
          <Route path='/stats' element={<Stats/>} />
          <Route path='/categoria' element={<Categoria/>} />
        </Routes>
      </div>
    </Router>
  </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
