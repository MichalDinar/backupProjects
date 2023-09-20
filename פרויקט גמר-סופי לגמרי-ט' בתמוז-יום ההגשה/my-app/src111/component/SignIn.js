import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
// import { useAuthContext } from '../auth/useAuthContext';
import { useNavigate } from 'react-router-dom';
// import SignUp from './SignUp';
// import { AuthContext } from '../auth/AuthContext';

import  {  useRef } from "react";
import { useSelector, useDispatch } from 'react-redux'
import {  getUSERNamePassord } from "../redux/action";

function Copyright(props) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

//const theme = createTheme();
const theme = createTheme({
  palette: {
    secondary: {
      main: "#f44336",
    },
    primary: {
      main: "#1A0539",
    },
  },
});

export default function SignIn() {
  const dispatch = useDispatch()
  const userId = useSelector(state => state.userR.userId)
  // const { login } = useAuthContext()
  const navigate = useNavigate()
    

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
       const data = new FormData(event.currentTarget);
      // console.log("1   "+data.get('email')+" "+data.get('password')) 
      //    const user={
      //     userId:1,
      //     userType: result.userType
      // }
      let user1 = { name: "123@gmail.com", password: 123 };
    debugger
      dispatch(getUSERNamePassord(user1))
      // var result=await login(data.get('email'),data.get('password'));
      //console.log("in singIn: userId: "+user.userId+"userType: "+user.userType);
  
      // console.log("signin");
      // console.log(user);
      // navigate('/home')
    } catch (error) {

    }
  };

 

  return (
    <>
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
              name="email"
              autoComplete="email"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              autoComplete="current-password"
            />
            {/* <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember me"
            /> */}
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>
            <Grid container>
              {/* <Grid item xs>
                <Link href="#" variant="body2">
                  Forgot password?
                </Link>
              </Grid> */}
              <Grid item>
                <Link href="/SignUp" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        {/* <Copyright sx={{ mt: 8, mb: 4 }} /> */}
      </Container>
    </ThemeProvider>
 {userId}
    </> );
}