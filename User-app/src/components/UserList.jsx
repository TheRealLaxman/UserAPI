function UserList({ users, fetchUsers }) {

  const deleteUser = async (id) => {
    await fetch(`https://localhost:7080/api/User/${id}`, {
      method: "DELETE",
    });

    fetchUsers();
  };

  return (
    <div>
      {users.map((user) => (
        <div className="user-card" key={user.id}>
          <p>
            <strong>Name:</strong> {user.firstName} {user.lastName}
          </p>

          <p>
            <strong>Email:</strong> {user.email}
          </p>

          <p>
            <strong>Age:</strong> {user.age}
          </p>

          <p>
            <strong>Department:</strong>{" "}
            {user.department?.departmentName}
          </p>

          <p>
            <strong>City:</strong> {user.address?.city}
          </p>

          <button onClick={() => deleteUser(user.id)}>
            Delete
          </button>
        </div>
      ))}
    </div>
  );
}

export default UserList;