import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import NavigationBar from './NavigationBar';


import AddOrderForm from './pages/AddOrder';
import AddCollectionPointForm from './pages/AddCollectingPoint';
import AddEmployeeForm from './pages/AddEmployee';
import RoleGuard from './auth/RoleGuard'
import {  Routes,Navigate } from 'react-router-dom';
import SignIn from './pages/SignIn';
import ManagerPage from './pages/Manager';
import Home from './pages/Home';
import AuthGuard from './auth/AuthGuard'
import SignUp from './pages/SignUp';
import EmployeePage from './pages/DailyPlan';
import { useSelector } from 'react-redux';
import EmployeePageTry from './pages/DailyPlanTry';
import EmployeePageTry2 from './pages/DailyPlanT2';
import SignOut from './pages/SignOut';

function MainHome() {
  const userType = useSelector(state => state.userR.userType)
  return (
   
      <><div className="MainHome">
        <NavigationBar />
        <Routes>
          
          
          {/* <Route path="/SignOut" element={<AuthGuard><SignOut/></AuthGuard>} /> */}
          <Route path="/DailyPlan" element={<AuthGuard><EmployeePageTry2 /></AuthGuard>} />
          <Route path="/AddOrder" element={<AuthGuard><AddOrderForm /></AuthGuard>} />
          <Route path='/SignUp' element={<SignUp/>} />
          {/* <Route path='/SignUp' element={<RoleGuard><SignUp/></RoleGuard>} /> */}
          <Route path="/SignIn" element={<SignIn />} />
          <Route path="/OpenBussinesDay" element={<AuthGuard><ManagerPage /></AuthGuard>} />
          <Route path="/AddEmployee" element={<AuthGuard><AddEmployeeForm /></AuthGuard>} />
          <Route path="/AddCollectionPoint" element={<AuthGuard><AddCollectionPointForm /></AuthGuard>} />
          <Route path='/home' element={<Home />} />
          {/* <Route path='/home' element={<AuthGuard><Home /></AuthGuard>} /> */}
          <Route path='/' element={<Navigate to='/home' />} />
            <Route path='*' element={<h1>404 Page Not Found</h1>} />
        </Routes>
      </div>
    </>
  );
}

export default MainHome;