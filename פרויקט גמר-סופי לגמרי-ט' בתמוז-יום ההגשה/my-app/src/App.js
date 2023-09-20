
import './App.css';
import SignIn from './pages/SignIn'
//import AddCustomer from './AddCustomer'
//import AddEmployee from './AddEmployee'
//import AddCollectionPoint from './AddCollectionPoint';
//import AddOrder from './AddOrder'
import MainForm from './Main';
import NavigationBar  from './MainManager'
import App1 from './MainManager';
import MainHome from './MainMain';
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
// import AuthProvider from "./auth/AuthContext";
import store from '../src/redux/store';
import { Provider } from 'react-redux';
import AddEmployeeForm from './pages/AddEmployee';
import EmployeePage from './pages/DailyPlan';
import SignUp from './pages/SignUp';
import ManagerPage from './pages/Manager';
import AddCollectionPointForm from './pages/AddCollectingPoint';
import Home from './pages/Home';


function App() {
  return (
    <div className="App">
     {/* <SignIn /> */}
     {/* <AddCustomer/> */}
     {/* <AddEmployee/> */}
     {/* <AddCollectionPoint/>   */}
     {/* <AddOrder/> */}
      {/* <MainForm/> */}
      {/* <App1/> */}
      
      {/* <AuthProvider store={store}>
        <BrowserRouter>
        <MainHome /> 
        </BrowserRouter>
      </AuthProvider> */}
       {/* <AuthProvider> */}
       <Provider store={store}>

        <BrowserRouter>
        <MainHome /> 

          {/* <Routes>
          <Route path="/AddEmployee" element={<AddEmployeeForm />} />
          <Route path="/DailyPlan" element={<EmployeePage />} />
          <Route path='/SignUp' element={<SignUp/>} />
          <Route path="/SignIn" element={<SignIn />} />
          <Route path="/OpenBussinesDay" element={<ManagerPage />} />
          <Route path="/AddCollectionPoint" element={<AddCollectionPointForm />} />
          <Route path='/home' element={<Home/>} />
          <Route path='/' element={<Home/>} />
          <Route path='*' element={<h1>404 Page Not Found</h1>} />

          </Routes> */}
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;
