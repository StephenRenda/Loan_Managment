export const findLoan = (params) => {
  return fetch(
    `/api/loans/search?type=${params.type}&searchString=${params.key}`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};

export const findRecentLoan = (params) => {
  return fetch(
    `/api/loans/recent/${params.numRecords}`,
    {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};

export const editLoans = (params) => {
  return fetch(
    `/api/loans/edit?id=${params.id}`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
      body: JSON.stringify(params.loan),
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};

export const editBorrower = (params) => {
  return fetch(
    `/api/borrowers/edit?id=${params.id}`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
      body: JSON.stringify(params.loan),
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};


export const newLoan = (params) => {
  return fetch(
    `/api/loans`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
      body: JSON.stringify(params.loan),
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};

export const newBorrower = (params) => {
  return fetch(
    `/api/borrowers`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",      
      },
      body: JSON.stringify(params.borrower),
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};

export const editProperty = (params) => {
  return fetch(
    `/api/property/edit?id=${params.id}`,
    {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(params.loan),
    }
  )
    .then((response) => {
      return response.json();
    })
    .catch((err) => console.error(err));
};