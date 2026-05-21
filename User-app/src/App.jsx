import { useEffect, useState } from "react";
import UserForm from "./components/UserForm";
import UserList from "./components/UserList";

function App() {
  const [users, setUsers] = useState([]);

  const fetchUsers = async () => {
    const response = await fetch("https://localhost:7080/api/User");
    const data = await response.json();

    setUsers(data);
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <div className="container">
      <h1 className="title">User Management System</h1>

      <UserForm fetchUsers={fetchUsers} />

      <UserList users={users} fetchUsers={fetchUsers} />
    </div>
  );
}

export default App;