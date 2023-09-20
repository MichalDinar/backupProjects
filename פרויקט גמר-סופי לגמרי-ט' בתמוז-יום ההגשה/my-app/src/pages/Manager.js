import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import AccessTimeIcon from '@mui/icons-material/LockOutlined';
import QueryBuilderIcon from '@material-ui/icons/QueryBuilder';
import { openDay } from '../service/user.service';

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

export default function ManagerPage() {

  const [startTime, setStartTime] = React.useState('');
  const [endTime, setEndTime] = React.useState('');

  const handleOpenDay  = async (e) => {
    //debugger
    //e.preventDefault();
    console.log('hello');
    const open = startTime;
    const close = startTime;
    const bussinesDay = {
      open:startTime,
      close:endTime
    };
    try {
       
      //await axios.post('https://localhost:7182/api/employee', employee);
      console.log('open day')
      console.log(bussinesDay.open);
      console.log(bussinesDay.close);
      const res= await openDay(bussinesDay)
      console.log(res.data);
      //setAcknowledgment('Employee added successfully!');
      alert('The algorithm ran successfully!');
      setEndTime('')
      setStartTime('')
    } catch (error) {
      console.error(error);
      //setAcknowledgment('Failed to add employee.');
      alert('Failed to ran the algorithm.');
    }
  };
  const handleSubmit = async (e) => {
    e.preventDefault();
    if (startTime && endTime) {
      const confirmed = window.confirm('Are you sure you want to run the algorithm?');
      if (confirmed) {
        handleOpenDay();
      }
    }
  };

  return (
    // <ThemeProvider theme={theme}  onSubmit={handleSubmit}>
    <ThemeProvider theme={theme}  >
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}>
          
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
      {/* <AccessTimeIcon /> */}
      <QueryBuilderIcon />
        </Avatar>
          <Typography component="h1" variant="h5">
            Welcome to the manager
          </Typography>
          <Box component="form" noValidate sx={{ mt: 1 }} onSubmit={handleSubmit}>
          {/* <Box component="form" noValidate sx={{ mt: 1 }} onSubmit={handleSubmit}> */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="start-time"
              label="Start Time"
              name="start-time"
              type="time"
              value={startTime}
              onChange={(e)=>setStartTime(e.target.value)}
              InputLabelProps={{
                shrink: true,
              }}
              inputProps={{
                required: true,
              }}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="end-time"
              label="End Time"
              type="time"
              id="end-time"
              value={endTime}
              onChange={(e)=>setEndTime(e.target.value)}
              InputLabelProps={{
                shrink: true,
              }}
              inputProps={{
                required: true,
              }}
            />
            <Button
              fullWidth
              type="submit"
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              // onClick={handleAlgorithmActivation}
            >
              Activate Algorithm
            </Button>
          </Box>

        </Box>
      </Container>
    </ThemeProvider>
  );
}