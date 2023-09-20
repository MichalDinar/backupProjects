import React, { useState } from 'react';
import {
  TextField,
  Button,
  FormControl,
  InputLabel,
  Input,
  FormHelperText,
} from '@material-ui/core';

const AddCollectionPointForm = ({ onAddCollectionPoint }) => {
  // Initialize form state
  const [formValues, setFormValues] = useState({
    name: '',
    address: '',
  });

  // Handle form submit
  const handleSubmit = (event) => {
    event.preventDefault();
    onAddCollectionPoint(formValues);
    setFormValues({
      name: '',
      address: '',
    });
  };

  // Handle form input change
  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormValues((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormControl>
        <InputLabel htmlFor="name-input">Collection point name</InputLabel>
        <Input
          id="name-input"
          name="name"
          value={formValues.name}
          onChange={handleInputChange}
        />
      </FormControl>
      <FormControl>
        <InputLabel htmlFor="address-input">Collection point address</InputLabel>
        <Input
          id="address-input"
          name="address"
          value={formValues.address}
          onChange={handleInputChange}
        />
      </FormControl>
      <Button type="submit" variant="contained" color="primary">
        Add collection point
      </Button>
    </form>
  );
};

export default AddCollectionPointForm;