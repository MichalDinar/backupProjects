import { useState } from 'react';
import {
  Avatar,
  Box,
  Button,
  Container,
  CssBaseline,
  FormControl,
  IconButton,
  InputAdornment,
  InputLabel,
  ThemeProvider,
  createTheme,
  OutlinedInput,
  TextField,
  Typography,
} from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import axios from 'axios';
import { addEmployee } from '../service/Employee.service';

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

const AddEmployeeForm = () => {
  const [identityCard, setIdentityCard] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [street, setStreet] = useState('');
  const [city, setCity] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [acknowledgment, setAcknowledgment] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const address = `${street}, ${city}`;
    const employee = {
      employeeId:0,
      firstName,
      lastName,
      address,
      phone,
      mail: email,
      password,
    };
    try {
       
      //await axios.post('https://localhost:7182/api/employee', employee);
      const res= await addEmployee(employee)
      console.log(res.data);
      //setAcknowledgment('Employee added successfully!');
      alert('Employee added successfully!');
      setIdentityCard('');
      setFirstName('');
      setLastName('');
      setStreet('');
      setCity('');
      setPhone('');
      setEmail('');
      setPassword('');
    } catch (error) {
      console.error(error);
      //setAcknowledgment('Failed to add employee.');
      alert('Failed to add employee.');
    }
  };

  return (
    <ThemeProvider theme={theme}>
    <Container component="main" maxWidth="xs" >
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
          {/* <LockOutlinedIcon /> */}
        </Avatar>
        <Typography component="h1" variant="h5">
          Add Employee
        </Typography>
        <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
          {/* <TextField
            margin="normal"
            required
            fullWidth
            id="id"
            label="Identity Card"
            name="id"
            autoFocus
            value={identityCard}
            onChange={(e) => setIdentityCard(e.target.value)}
          /> */}
          <TextField
            margin="normal"
            required
            fullWidth
            id="firstName"
            label="First Name"
            name="firstName"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
          <TextField
            margin="normal"
            required
            fullWidth
            id="lastName"
            label="Last Name"
            name="lastName"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
          <TextField
            margin="normal"
            fullWidth
            id="street"
            label="Street"
            name="street"
            value={street}
            onChange={(e) => setStreet(e.target.value)}
          />
          <TextField
            margin="normal"
            fullWidth
            id="city"
            label="City"
            name="city"
            value={city}
            onChange={(e) => setCity(e.target.value)}
          />
          <TextField
            margin="normal"
            fullWidth
            id="phone"
            label="Phone"
            name="phone"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
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
            onChange={(e) => setEmail(e.target.value)}
          />
          <FormControl variant="outlined" fullWidth margin="normal" required>
            <InputLabel htmlFor="password">Password</InputLabel>
            <OutlinedInput
              id="password"
              name="password"
              type={showPassword ? 'text' : 'password'}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              endAdornment={
                <InputAdornment position="end">
                  <IconButton
                    onClick={() => setShowPassword(!showPassword)}
                    onMouseDown={(e) => e.preventDefault()}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
              label="Password"
            />
          </FormControl>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Add Employee
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

export default AddEmployeeForm;