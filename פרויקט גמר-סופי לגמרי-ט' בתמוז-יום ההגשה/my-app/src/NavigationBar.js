import React from 'react';
import { createTheme, ThemeProvider } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { Link, Navigate } from 'react-router-dom';
import useAuthContext from './auth/useAuthContext';
import { useDispatch, useSelector } from 'react-redux';
import { logout, signOut } from './redux/action';

// import { useHistory } from 'react-router-dom';
// import { createBrowserHistory } from 'history';

const theme = createTheme({
  palette: {
    primary: {
      main: '#1A0539',
    },
    secondary: {
      main: '#f44336',
    },
  },
});


 function NavigationBar() {
 
  const userType = useSelector(state => state.userR.userType)
  const dispatch = useDispatch()
  //const history = createBrowserHistory();

  // גישה למידע של המשתמש המחובר
  //const { user, isAuthenticated } = useAuthContext()

  // אם המשתמש לא מחובר, לא נציג תפריט הניווט
  // if (!isAuthenticated) {
  //     return null
  // }
  const handleLogout = () => {
    dispatch(logout());
    //history.push('/');
  };

  return (
    <ThemeProvider theme={theme}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6">
          <button type="button" onClick={handleLogout} 
          // style={{ color: 'white', backgroundColor: 'transparent',
          //  border: 'none', cursor: 'pointer', marginRight: '1rem',marginRight: 'auto' }
          style={{ color: 'white', backgroundColor: 'transparent',
            border: 'none', cursor: 'pointer', marginRight: '1rem',marginRight: 'auto', fontSize: '1.2rem'}}
        >
            Log-Out
          </button>
          </Typography>
          <Typography variant="h6" style={{ marginLeft: 'auto' }}>
         
         
          <Link to="/SignUp" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Sign-Up
            </Link>
             {/* )} */}
          <Link to="/SignIn" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Sign-In
            </Link>
            <Link to="/home" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Home
            </Link>
           {userType==3 &&
          <>
          <Link to="/home" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Home
            </Link>
            <Link to="/AddOrder" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
            Add-Order
            </Link>
           
             </>
          }
          {userType==1 &&
          <>
            <Link to="/home" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Home
            </Link>
            <Link to="/DailyPlan" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
            Daily-Plan
            </Link>
          </>

          }
          {userType==2 &&
          <>
          <Link to="/home" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
              Home
            </Link>
            <Link to="/AddEmployee" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
             Add-Employee 
            </Link>
            
            <Link to="/AddCollectionPoint" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
             Add-CollectionPoint 
            </Link>
            <Link to="/OpenBussinesDay" style={{ color: 'white', textDecoration: 'none', marginRight: '1rem' }}>
             Open-Bussines-Day 
            </Link>
          </>

          }
          </Typography>
        </Toolbar>
      </AppBar>
    </ThemeProvider>
  );
}

export default NavigationBar;