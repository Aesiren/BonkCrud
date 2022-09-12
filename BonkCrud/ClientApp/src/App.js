import React, { Component } from 'react';
import AddItem from './components/AddItem';
import GetItem from './components/GetItem';
import EditItem from './components/EditItem';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
//import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';

function App() {
    return (
        <Router>
            <div className="container">
                <nav classname="navbar navbar-expand-lg navheader">
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item">
                                <link to={'/AddItem'} className="nav-link">AddItem</link>
                            </li>
                            <li className="nav-item">
                                <Link to={'GetItem'} className="nav-link">Item List</Link>
                            </li>
                        </ul>
                    </div>
                </nav> <br />
                <Routes>
                    <Route exact path='/AddItem' componenet={AddItem} />
                    <Route path='/edit/:id' component={EditItem} />
                    <Route path='/GetItem' componenet={GetItem} />
                </Routes>
            </div>

        </Router>


    );
 
}



export default App;




/*export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}*/
