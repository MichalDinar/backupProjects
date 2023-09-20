// import * as React from 'react';
// import Box from '@mui/material/Box';
// import TextField from '@mui/material/TextField';
// import MenuItem from '@mui/material/MenuItem';
// import Typography from '@mui/material/Typography';
// import Button from '@mui/material/Button';
// import DeleteIcon from '@mui/icons-material/Delete';
// import SendIcon from '@mui/icons-material/Send';
// import Stack from '@mui/material/Stack';
// import CheckBoxOutlineBlankIcon from '@mui/icons-material/CheckBoxOutlineBlank';
// import CheckBoxIcon from '@mui/icons-material/CheckBox';
// import Checkbox from '@mui/material/Checkbox';
// import Autocomplete from '@mui/material/Autocomplete';
// import { getProfessions as getProfessionFromApi } from "../services/profession.service"
// import { getTeacher as getTeachersFromApi } from "../services/teacher.service"
// import { getPupils as getPupilsFromApi } from "../services/pupil.service"
// import { register as registerFromApi } from "../services/group.service"
// // import { Margin } from '@mui/icons-material';
// // import { Grid } from '@mui/material';

// const icon = <CheckBoxOutlineBlankIcon fontSize="small" />;
// const checkedIcon = <CheckBoxIcon fontSize="small" />;

// const classes = [{
//   label: 'T', value: '1', },
//   {label: 'Y',value: '2',},
//   {label: 'Y', value: '3', },
//   { label: '12', value: '4',
//   },
// ];

// const tableStyles = {
//   borderCollapse: 'collapse',
//   width: '80%',
//   '& th, td': {
//     border: '1px solid black',
//     padding: '80px',
//     textAlign: 'center'
//   },
//   '& th': {
//     backgroundColor: '#f2f2f2' }
// }
// export default function FormPropsTextFields() {
//   const [tableData, setTableData] = React.useState({ teacher: [], profession: [] ,pupil:[]});
//   const[formValues,setFormValues]= React.useState({})
//   const [selectedPupils, setSelectedPupils] = React.useState([]);

//   function handleSubmit(e) {
//     e.preventDefault();
//     const group = {
//       teacherId: formValues.teacher.teacherId,
//       lessonsNumber: formValues.lessonsNumber,
//       professionId: formValues.professions.professionId,
//       pupils: selectedPupils.map(pupil => pupil.pupilId)
//     };
//     registerFromApi(group)
//       .then((response) => {
//         console.log("Group registered successfully:", response);
//         setFormValues({})
//         setSelectedPupils([]);
//       })
//       .catch((error) => {
//         console.log("Error registering group:", error);
//       });
//   }
// //מזמן את כל הקריאות למסד נתונים ומכניס אותם לתוך המערכים המוכנים למעלה
// //מעדכן בטעינה של הטופס
//   React.useEffect(() => {
//     async function fetchData() {
//       const teacher = await getTeachersFromApi();
//       const profession = await getProfessionFromApi();
//       const pupil = await getPupilsFromApi();
//       setTableData({ teacher, profession, pupil }); }
//     fetchData();
//   }, []);

//   const handleChanges = (event) => {
//     setFormValues({
//       ...formValues,[event.target.name]:event.target.value, }) };

//   const handlePupilSelection = (event) => {
//     const selectedPupil = event.target.value;
//     setSelectedPupils(prevSelectedPupils => {
//       const pupilIndex = prevSelectedPupils.findIndex(pupil => pupil.pupilId === selectedPupil.pupilId);
//       if (pupilIndex === -1) {
//         return [...prevSelectedPupils, selectedPupil];
//       } else {
//         return [...prevSelectedPupils.slice(0, pupilIndex), ...prevSelectedPupils.slice(pupilIndex + 1)]
//       }
//     });
//   }

//   return (
//     <Box
//       component="form"
//       sx={{
//         '& .MuiTextField-root': { m: 1, width: '40ch'},
//         // '& .MuiTextField-root': { m: 1, width: '40ch',marginRight:'1000px' },
//       }}
//       noValidate
//       autoComplete="off"
//       dir="rtl"
//     >        
    
//       <div >
//       <Typography variant="h3" gutterBottom color="secondary">
//         Adding a reinforcement group
//       </Typography>
//       </div>
//       <div>
//            <div style={{float: 'left',width:'50%'}} >
       
//       <div >
//       <TextField
//       id="teacher"
//       select
//       required
//       label="Teacher"
//       name="teacher"
//       value={formValues.teacher||''}
//       color="secondary"
//       onChange={handleChanges}
//     >
//       {tableData.teacher.map((option) => (
//         <MenuItem key={option.teacherId} value={option.lastName+option.firstName}>
//           {option.firstName}
//           {" "}
//           {option.lastName}
//         </MenuItem>
//       ))}
//         </TextField>
//        </div>
        
//        <div>
//         <TextField
//           id="Grade"
//           select
//           required
//           label="Grade"
//           color="secondary"
//         >
//           {classes.map((option) => (
//             <MenuItem key={option.label} value={option.value}>
//               {option.label}
//             </MenuItem>
//           ))}
//         </TextField>
//         </div>
//          <div>
//         <TextField
//           id="Profession"
//           select
//           required
//           label="Profession"
//           name="professions"
//           value={formValues.profession||''}
//           color="secondary"        >
//           {tableData.profession.map((option) => (
//             <MenuItem key={option.professionId} value={option.subjectName}>
//               {option.subjectName}
//             </MenuItem>
//           ))}
//         </TextField>
//         </div>
//         <div>
//         <TextField
//           id="lessonsNumber"
//           label="LessonsNumber"
//           name="lessonsNumber"
//           required
//           value={formValues.lessonsNumber||1}
//           type="number"
//           color="secondary"
//           //defaultValue="1"
//           onChange={handleChanges}
//           InputLabelProps={{
//             shrink: true,
//           }}
//         /></div>
//           </div>  
//           <div style={{float: 'right',width:'50%'}}>
          
//         <table style={tableStyles}>
//           <thead>
//             <tr>
//               <th>Select</th>
//               <th>First Name</th>
//               <th>Last Name</th>
//             </tr>
//           </thead>
//           <tbody>
//             {tableData.pupil.map((pupil) => (
//               <tr key={pupil.pupilId}>
//                 <td>
//                   <Checkbox
//                     checked={selectedPupils.some(selectedPupil => selectedPupil.pupilId === pupil.pupilId)}
//                     onChange={handlePupilSelection}
//                     value={pupil}
//                   />
//                 </td>
//                 <td>{pupil.firstName}</td>
//                 <td>{pupil.lastName}</td>
//               </tr>
//             ))}
//           </tbody>
//         </table>
//         </div>
//         </div>
//         <Stack direction="row" justifyContent="center" style={{width:'100%'}} spacing={2} >
//       {/* <Button variant="outlined" color="secondary" endIcon={<DeleteIcon />}>
//         Delete
//       </Button> */}
//       <span/>
//       <Button  variant="outlined" color="secondary" onClick={handleSubmit} endIcon={<SendIcon />}>
//         Send
//       </Button>
//       {/* <Button variant="outlined" color="secondary" endIcon={<IconButton />}>
//         Update
//       </Button> */}
//       </Stack>
    
//     </Box>
    
//   );
// }