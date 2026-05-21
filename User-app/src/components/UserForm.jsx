import { useState } from "react";

function UserForm({ fetchUsers }) {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    age: "",
    departmentId: "",
    city: "",
    state: "",
    country: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const userData = {
      firstName: formData.firstName,
      lastName: formData.lastName,
      email: formData.email,
      age: Number(formData.age),
      departmentId: Number(formData.departmentId),

      address: {
        city: formData.city,
        state: formData.state,
        country: formData.country,
      },
    };

    await fetch("https://localhost:7080/api/User", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userData),
    });

    fetchUsers();

    setFormData({
      firstName: "",
      lastName: "",
      email: "",
      age: "",
      departmentId: "",
      city: "",
      state: "",
      country: "",
    });
  };

  return (
    <form onSubmit={handleSubmit} className="form-container">
      <input
        type="text"
        name="firstName"
        placeholder="First Name"
        value={formData.firstName}
        onChange={handleChange}
      />

      <input
        type="text"
        name="lastName"
        placeholder="Last Name"
        value={formData.lastName}
        onChange={handleChange}
      />

      <input
        type="email"
        name="email"
        placeholder="Email"
        value={formData.email}
        onChange={handleChange}
      />

      <input
        type="number"
        name="age"
        placeholder="Age"
        value={formData.age}
        onChange={handleChange}
      />

      <input
        type="number"
        name="departmentId"
        placeholder="Department ID"
        value={formData.departmentId}
        onChange={handleChange}
      />

      <input
        type="text"
        name="city"
        placeholder="City"
        value={formData.city}
        onChange={handleChange}
      />

      <input
        type="text"
        name="state"
        placeholder="State"
        value={formData.state}
        onChange={handleChange}
      />

      <input
        type="text"
        name="country"
        placeholder="Country"
        value={formData.country}
        onChange={handleChange}
      />

      <button type="submit">Add User</button>
    </form>
  );
}

export default UserForm;