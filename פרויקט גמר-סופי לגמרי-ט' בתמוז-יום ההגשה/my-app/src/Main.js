// import React, { useState } from 'react';
// import AddClientForm from './pages/SignUp'
// import AddOrderForm from './pages/AddOrder'
// import AddEmployeeForm from './pages/AddEmployee';



// import {
//   Box,
//   Button,
//   Container,
//   CssBaseline,
//   Grid,
//   Paper,
//   Typography,
// } from '@mui/material';
// import { createTheme, ThemeProvider } from '@mui/material/styles';
// import SignIn from './pages/SignIn';
// import ManagerPage from './pages/Manager';
// import EmployeePage from './pages/DailyPlan';
// //import CollectionPointsTable from './try';


// //import AddCollectionPointForm from './try';
// import AddCollectionPointForm from './pages/AddCollectingPoint'

// const theme = createTheme({
//   palette: {
//     secondary: {
//       main: "#f44336",
//     },
//     primary: {
//       main: "#1A0539",
//     },
//   },
// });

// const MainForm = () => {
//   const [selectedForm, setSelectedForm] = useState('client');

//   const handleFormSelection = (form) => {
//     setSelectedForm(form);
//   };

//   const renderForm = () => {
//     switch (selectedForm) {
//       case 'client':
//         return <AddClientForm />;
//       case 'order':
//         return <AddOrderForm />;
//       case 'employee':
//         return <AddEmployeeForm/>;
//     case 'sighnIn':
//         return <SignIn/>;
//     case 'manager':
//         return <ManagerPage/>
//         case 'daily':
//           return <EmployeePage/>
//           case 'collectingPoint':
//           return <AddCollectionPointForm/>
//       default:
//         return null;
//     }
//   };

//   return (
//     <ThemeProvider theme={theme}>
//       <Container component="main" maxWidth="md">
//         <CssBaseline />
//         <Paper sx={{ my: 8, mx: 4, p: 3 }}>
//           <Typography component="h1" variant="h4" align="center">
//             Main Form
//           </Typography>
//           <Box sx={{ mt: 3 }}>
//             <Grid container spacing={2}>
//             <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="primary"
//                   onClick={() => handleFormSelection('sighnIn')}
//                 >
//                   Sighn In
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="primary"
//                   onClick={() => handleFormSelection('client')}
//                 >
//                   Sighn Up
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="secondary"
//                   onClick={() => handleFormSelection('order')}
//                 >
//                   Add Order
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="secondary"
//                   onClick={() => handleFormSelection('employee')}
//                 >
//                   Add Employee
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="secondary"
//                   onClick={() => handleFormSelection('manager')}
//                 >
//                   Manager
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="secondary"
//                   onClick={() => handleFormSelection('daily')}
//                 >
//                   Daily Plan
//                 </Button>
//               </Grid>
//               <Grid item xs={12} sm={6}>
//                 <Button
//                   fullWidth
//                   variant="contained"
//                   color="secondary"
//                   onClick={() => handleFormSelection('collectingPoint')}
//                 >
//                   collectingPoint
//                 </Button>
//               </Grid>
//             </Grid>
//           </Box>
//           <Box sx={{ mt: 3 }}>
//             {renderForm()}
//           </Box>
//         </Paper>
//       </Container>
//     </ThemeProvider>
//   );
// };

// export default MainForm;