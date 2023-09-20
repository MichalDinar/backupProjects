import { useState } from 'react';
import {
  Avatar,
  Box,
  Button,
  Container,
  CssBaseline,
  TextField,
  Typography,
  ThemeProvider,
  createTheme,
} from '@mui/material';
import axios from 'axios';
import AddLocationOutlinedIcon from '@mui/icons-material/AddLocationOutlined';
import { addCollectingPoints } from '../service/CollectingPoints.service';

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

const AddCollectionPointForm = () => {
  const [collectingPointName, setName] = useState('');
  const [street, setStreet] = useState('');
  const [city, setCity] = useState('');
  const colPointType = 1;
  
  const [acknowledgment, setAcknowledgment] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const address = `${street}, ${city}`;
    const collectionPoint = {
      collectingPointId:0,
      collectingPointName:collectingPointName,
      locationX:0,
      locationY:0,
      address,
      state:1,
      colPointType:1,
      packageId:null

      
    };
    console.log(collectionPoint.collectingPointName)

    try {
      //collectionPoint.colPointType=1;
      const res=await addCollectingPoints(collectionPoint)
      console.log(res.data);
      alert('Collection point added successfully!');
      setName('');
      setStreet('');
      setCity('');
    } catch (error) {
      console.error(error);
      alert('Failed to add collection point.');
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
            <AddLocationOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Add Collection Point
          </Typography>
          <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="name"
              label="Collection Point Name"
              name="name"
              autoFocus
              value={collectingPointName}
              onChange={(e) => setName(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="street"
              label="Street"
              name="street"
              value={street}
              onChange={(e) => setStreet(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="city"
              label="City"
              name="city"
              value={city}
              onChange={(e) => setCity(e.target.value)}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Add Collection Point
            </Button>
            {acknowledgment && (
              <Typography variant="body2" color="text.secondary" align="center">
                {acknowledgment}
              </Typography>
            )}
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default AddCollectionPointForm;