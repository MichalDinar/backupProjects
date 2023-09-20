import React from 'react';
import  { useState,useEffect } from 'react';
import {addClient} from '../service/ClientsService' 
import {createTheme, ThemeProvider } from '@mui/material/styles';
import {
  Avatar,
  Box,
  Button,
  Checkbox,
  Container,
  CssBaseline,
  FormControlLabel,
  Grid,
  Link,
  TextField,
  Typography,
} from '@mui/material';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import axios from 'axios';

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

 

export default function SignUp({ handleAddCustomer }) {
    
    //const classes = useStyles();
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  


  const handleSubmit = async (event) => {
    event.preventDefault();
    
    var client={
      clientId: 0,
      firstName:firstName,
      lastName:lastName ,
      phone: phone,
      mail:email ,
      password: password
    }
  


    console.log(client);
    try {
      //const response = await axios.post("https://localhost:7182/api/client", client);
      const response = await addClient(client);
      //const response = addCxlient(client)
      console.log(response.data);
      alert('Customer added successfully!')
      
      setFirstName('');
      setLastName('');
      setPhone('');
      setEmail('');
      setPassword('');

      

    } catch (error) {
      console.error(error);
      alert('Failed to add customer.');
    }


    //console.log(client);
    //var promise= await axios.post("https://localhost:7182/api/client",client);
    //console.log(promise.data);

    // Add code here to submit the form data to your backend or store it in state
  };

  useEffect(() => {
    console.log('State variables updated:', firstName, lastName, phone, email, password);
    setFirstName(firstName);
    setLastName(lastName);
    setPhone(phone);
    setEmail(email);
    setPassword(password);
  }, [ firstName, lastName, phone, email, password]);

  return (
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
            Sign Up
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
           
            <TextField
              margin="normal"
              required
              fullWidth
              id="firstName"
              label="First Name"
              name="firstName"
              value={firstName}
              onChange={(e) =>setFirstName(e.target.value)}
              />
            <TextField
              margin="normal"
              required
              fullWidth
              id="lastName"
              label="Last Name"
              name="lastName"
              value={lastName}
              onChange={(e) =>setLastName(e.target.value)}
            />
            <TextField
              margin="normal"
              fullWidth
              id="phone"
              label="Phone"
              name="phone"
              value={phone}
              onChange={(e) =>setPhone(e.target.value)}
             />
            <TextField
              margin="normal"
              required
              fullWidth
              name="email"
              label="Email Address"
              type="email"
              id="email"
              value={email}
              onChange={(e) =>setEmail(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              value={password}
              onChange={(e) =>setPassword(e.target.value)}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
            <Grid container>
              
              <Grid item>
                <Link href="/SignIn" variant="body2">
                  {"Do have an account? Sign In"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}