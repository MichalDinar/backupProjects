import React, { useState } from 'react';
import axios from 'axios';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import {
  Avatar,
  Box,
  Button,
  Container,
  CssBaseline,
  TextField,
  Typography,
} from '@mui/material';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { addOrder } from '../service/Orders.service';
import { useSelector } from 'react-redux';

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

const AddOrderForm = () => {
  const [sourceCity, setSourceCity] = useState('');
  const [sourceStreet, setSourceStreet] = useState('');
  const [sourceBuildingNumber, setSourceBuildingNumber] = useState('');
  const [destinationCity, setDestinationCity] = useState('');
  const [destinationStreet, setDestinationStreet] = useState('');
  const [destinationBuildingNumber, setDestinationBuildingNumber] = useState('');
    const userId = useSelector(state => state.userR.userId)


  const handleSubmit = async (event) => {
    event.preventDefault();
    
    const order = {
      clientId:userId,
      packageId:0,
      addressSource: sourceStreet+' '+sourceBuildingNumber+', '+sourceCity,
      addressDestination: destinationStreet+' '+destinationBuildingNumber+', '+destinationCity
      
    };

    try {
      console.log(order.sourceAddress);
      console.log(order.destinationAddress);
      console.log(order.clientId);
      const response = await addOrder(order)
      
      console.log(response.data);
      alert('Order added successfully!');
      
      setSourceCity('');
      setSourceStreet('');
      setSourceBuildingNumber('');
      setDestinationCity('');
      setDestinationStreet('');
      setDestinationBuildingNumber('');
    } catch (error) {
      console.error(error);
      alert('Failed to add order.');
    }
  };

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
            Add a new order
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="sourceCity"
              label="Source City"
              name="sourceCity"
              autoFocus
              value={sourceCity}
              onChange={(e) => setSourceCity(e.target.value)}
              
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="sourceStreet"
              label="Source Street"
              name="sourceStreet"
              value={sourceStreet}
              onChange={(e) =>setSourceStreet(e.target.value)}
              />
            <TextField
              margin="normal"
              required
              fullWidth
              id="sourceBuildingNumber"
              label="Source Building Number"
              name="sourceBuildingNumber"
              value={sourceBuildingNumber}
              onChange={(e) =>setSourceBuildingNumber(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="destinationCity"
              label="Destination City"
              name="destinationCity"
              value={destinationCity}
              onChange={(e) =>setDestinationCity(e.target.value)}
             />
            <TextField
              margin="normal"
              required
              fullWidth
              id="destinationStreet"
              label="Destination Street"
              name="destinationStreet"
              value={destinationStreet}
              onChange={(e) =>setDestinationStreet(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="destinationBuildingNumber"
              label="Destination Building Number"
              name="destinationBuildingNumber"
              value={destinationBuildingNumber}
              onChange={(e) =>setDestinationBuildingNumber(e.target.value)}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Add Order
            </Button>
           
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default AddOrderForm;