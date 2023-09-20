// import * as React from 'react';
// import Avatar from '@mui/material/Avatar';
// import Box from '@mui/material/Box';
// import Button from '@mui/material/Button';
// import CssBaseline from '@mui/material/CssBaseline';
// import Grid from '@mui/material/Grid';
// import Paper from '@mui/material/Paper';
// import Table from '@mui/material/Table';
// import TableBody from '@mui/material/TableBody';
// import TableCell from '@mui/material/TableCell';
// import TableContainer from '@mui/material/TableContainer';
// import TableHead from '@mui/material/TableHead';
// import TableRow from '@mui/material/TableRow';
// import Typography from '@mui/material/Typography';
// import { createTheme, ThemeProvider } from '@mui/material/styles';
// import Toolbar from '@mui/material/Toolbar';
// import Container from '@mui/material/Container';
// import { getAllPartialDelivery } from '../service/partialDelivery.service';
// import { getAllPartialDeliveryToPackage } from '../service/partialDeliveryToPackage.service';
// import { useSelector } from 'react-redux';

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

// const collectionPoints = [
//   {
//     id: 38,
//     address: 'Rothovski 8 St, Petach Tikva',
//     packages: [
//       {
//         id: 27,
//         type: 'upload',
//       },
//       {
//         id: 14,
//         type: 'download',
//       }
//     ]
//   },
//   {
//     id: 43,
//     address: 'Rabi Akiva 100 St, Bney Brak',
//     packages: [
//       {
//         id: 23,
//         type: 'upload',
//       },
//       {
//         id: 48,
//         type: 'download',
//       }
//     ]
//   },
//   {
//     id: 13,
//     address: 'Ben Guryon 8, Tel Aviv',
//     packages: [
//       {
//         id: 84,
//         type: 'upload',
//       },
//       {
//         id: 34,
//         type: 'download',
//       },
      
//       {
//         id: 24,
//         type: 'download',
//       }
//     ]
//   },
//   {
//     id: 13,
//     address: 'Ben Guryon 8, Tel Aviv',
//     packages: [
//       {
//         id: 84,
//         type: 'upload',
//       },
//       {
//         id: 34,
//         type: 'download',
//       },
//       {
//         id: 24,
//         type: 'download',
//       }
//     ]
//   }
// ];

// export default function EmployeePageTry({ name }) {


//   const [expandedRow, setExpandedRow] = React.useState(null);

//   const [tableData, setTableData] = React.useState({ partialDelivery: [], partialDeliveryToPackage: [] });
//   const[formValues,setFormValues]= React.useState({})
//   const [selectedPupils, setSelectedPupils] = React.useState([]);
//   const userId = useSelector(state => state.userR.userId)

//   const partialDelivery=React.useState([{}])

//   React.useEffect(() => {
//     async function fetchData() {
//        partialDelivery = await getAllPartialDelivery(userId);
//     //    partialDelivery.map(r) => {

//     //    }
//     //    collectionPoints.push()
//     //   debugger
//       // const collectionPoints1=[{
//       //   partialDelivery.map()
//       //   id: 38,
//       //   address: 'Rothovski 8 St, Petach Tikva',
//       //   packages: [
//       //     {
//       //       id: 27,
//       //       type: 'upload',
//       //     },
//       //     {
//       //       id: 14,
//       //       type: 'download',
//       //     }
//       //   ]
//       // },
//       // ]
//       // const partialDeliveryToPackage = await getAllPartialDeliveryToPackage();
//       setTableData({ partialDelivery }); }
//     fetchData();
//   }, []);


//     name="Israel"
//   const handleRowClick = (row) => {
//     if (expandedRow === row) {
//       setExpandedRow(null);
//     } else {
//       setExpandedRow(row);
//     }
//   };

//   return (
//     <>
//   { partialDelivery && partialDelivery.map((i)=>{
//         return (
//             <>
//         {i.collectingPointId}
//         </>)
//     }
//   )} </>
//     // <ThemeProvider theme={theme}>
//     //   <CssBaseline />
//     //   <Box sx={{ display: 'flex' }}>
//     //     <Box
//     //       component="main"
//     //       sx={{
//     //         backgroundColor: (theme) => theme.palette.background.default,
//     //         flexGrow: 1,
//     //         height: '100vh',
//     //         overflow: 'auto',
//     //       }}
//     //     >
//     //       <Toolbar />
//     //       <Box sx={{ my: 2 }}>
//     //         <Typography variant="h4" align="center">
//     //           Hello to {name}
//     //         </Typography>
//     //       </Box>
//     //       <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
//     //         <Grid container spacing={3}>
//     //           <Grid item xs={12}>
//     //             <TableContainer component={Paper}>
//     //               <Table>
//     //                 <TableHead>
//     //                   <TableRow>
//     //                     <TableCell>#</TableCell>
//     //                     <TableCell>Collection Point Number</TableCell>
//     //                     <TableCell>Address</TableCell>
//     //                   </TableRow>
//     //                 </TableHead>
//     //                 <TableBody>
//     //                   {collectionPoints.map((collectionPoints, index) => (
//     //                     <React.Fragment key={collectionPoints.id}>
//     //                       <TableRow onClick={() => handleRowClick(index)}>
//     //                         <TableCell>{index + 1}</TableCell>
//     //                         <TableCell>{collectionPoints.id}</TableCell>
//     //                         <TableCell>{collectionPoints.address}</TableCell>
//     //                       </TableRow>
//     //                       {expandedRow === index && (
//     //                         <TableRow>
//     //                           <TableCell colSpan={3}>
//     //                             <TableContainer component={Paper}>
//     //                               <Table>
//     //                                 <TableHead>
//     //                                   <TableRow>
//     //                                     <TableCell>Package ID</TableCell>
//     //                                     <TableCell>Status</TableCell>
//     //                                   </TableRow>
//     //                                 </TableHead>
//     //                                 <TableBody>
//     //                                   {collectionPoints.packages.map((packageData) => (
//     //                                     <TableRow key={packageData.id}>
//     //                                       <TableCell>{packageData.id}</TableCell>
//     //                                       <TableCell>{packageData.type}</TableCell>
//     //                                     </TableRow>
//     //                                   ))}
//     //                                 </TableBody>
//     //                               </Table>
//     //                             </TableContainer>
//     //                           </TableCell>
//     //                         </TableRow>
//     //                       )}
//     //                     </React.Fragment>
//     //                   ))}
//     //                 </TableBody>
//     //               </Table>
//     //             </TableContainer>
//     //           </Grid>
//     //         </Grid>
//     //       </Container>
//     //     </Box>
//     //   </Box>
//     // </ThemeProvider>
//  );
// }