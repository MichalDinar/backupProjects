import React from 'react';
import { useSelector } from 'react-redux';
import {
  Box,
  Container,
  CssBaseline,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Toolbar,
  Typography,
  ThemeProvider,
  createTheme,
} from '@mui/material';
import { getAllPartialDelivery } from '../service/partialDelivery.service';
//import { getAllPartialDelivery } from './api'; // assuming you have an API file that exports this function

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

const EmployeePageTry2 = () => {
  const [expandedRow, setExpandedRow] = React.useState(null);
  const [tableData, setTableData] = React.useState({ partialDelivery: [], partialDeliveryToPackage: [] });
  const [formValues, setFormValues] = React.useState({});
  const [selectedPupils, setSelectedPupils] = React.useState([]);
  const [date, setDate] = React.useState([]);
  const userId = useSelector(state => state.userR.userId);

  const [partialDelivery, setPartialDelivery] = React.useState([]);

  React.useEffect(() => {
    async function fetchData() {
      const partialDeliveryData = await getAllPartialDelivery(userId);
      debugger
      setPartialDelivery(partialDeliveryData);
      setDate(new Date(partialDeliveryData?.item1[0]?.estimatedTimeOfArrival).toLocaleDateString());

    }
    fetchData();
  }, []);

  const handleRowClick = (row) => {
    if (expandedRow === row) {
      setExpandedRow(null);
    } else {
      setExpandedRow(row);
    }
  };

  const renderPackageTable = (packages) => (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Package ID</TableCell>
            <TableCell>Status</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {packages.map((packageData) => (
            <TableRow key={packageData.packageId}>
              <TableCell>{packageData.packageId}</TableCell>
              <TableCell>{packageData.isTakenOrDownloaded ? 'download' : 'take'}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Box sx={{ display: 'flex' }}>
        <Box
          component="main"
          sx={{
            backgroundColor: (theme) => theme.palette.background.default,
            flexGrow: 1,
            height: '100vh',
            overflow: 'auto',
          }}
        >
          <Toolbar />
          <Box sx={{ my: 2 }}>
            <Typography variant="h4" align="center">
              Daily Plan of {date}
            </Typography>
          </Box>
          <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <TableContainer component={Paper}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>#</TableCell>
                        {/* <TableCell>Partial Delivery ID</TableCell> */}
                        {/* <TableCell>Employee ID</TableCell> */}
                        <TableCell>Estimated Time of Arrival</TableCell>
                        <TableCell>Collecting Point ID</TableCell>
                        <TableCell>Index of Delivery</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {partialDelivery.item1 && partialDelivery.item1.map((partialDeliveryData, index) => (
                        <React.Fragment key={partialDeliveryData.partialDeliveryId}>
                          <TableRow onClick={() => handleRowClick(index)}>
                            <TableCell>{index + 1}</TableCell>
                            {/* <TableCell>{partialDeliveryData.partialDeliveryId}</TableCell> */}
                            {/* <TableCell>{partialDeliveryData.employeeId}</TableCell> */}
                            {/* <TableCell>{partialDeliveryData.estimatedTimeOfArrival || '-'}</TableCell> */}
                            <TableCell>{new Date(partialDeliveryData.estimatedTimeOfArrival)?.toLocaleTimeString() || '-'}</TableCell>
                            {/* <TableCell>{partialDeliveryData?.estimatedTimeOfArrival?.toLocaleTimeString()}</TableCell> */}
                            <TableCell>{partialDeliveryData.collectingPointId}</TableCell>
                            <TableCell>{partialDeliveryData.indexOfDelivery}</TableCell>
                          </TableRow>
                          {expandedRow === index && (
                            <TableRow>
                              <TableCell colSpan={6}>
                                {renderPackageTable(
                                  partialDelivery.item2.filter(
                                    (packageData) => packageData.partialDeliveryId === partialDeliveryData.partialDeliveryId
                                  )
                                )}
                              </TableCell>
                            </TableRow>
                          )}
                        </React.Fragment>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>
              </Grid>
            </Grid>
          </Container>
        </Box>
      </Box>
    </ThemeProvider>
  );
};

export default EmployeePageTry2;