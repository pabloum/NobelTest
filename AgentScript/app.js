
const endpointUrl = "https://api.sampleapis.com/codingresources/codingResources";

function createCell(content) {
    const cell = document.createElement('td'); 
    cell.textContent = content;
    cell.classList = "dynamic-td"
    return cell
}

function createLinkCell(content, url) {
    const cell = document.createElement('td');
    const link = document.createElement('a');
    cell.classList = "dynamic-td"

    link.textContent = content;
    link.href = url;
    link.target = "_blank"; 

    cell.appendChild(link);
    return cell;
}

function createTableRow(description, url, types, topics) {
    const row = document.createElement('tr');
    
    row.appendChild(createLinkCell(description, url));
    row.appendChild(createCell(types));
    row.appendChild(createCell(topics));
    
    return row;
}

function addRowsToTable(data) {
    const table = document.getElementById('data-table');
    data.forEach(item => {
        const row = createTableRow(item.description, item.url, item.types, item.topics);
        table.appendChild(row);
    });
}

fetch(endpointUrl)
  .then(response => {
    if (!response.ok) {
      throw new Error('Error');
    }
    return response.json();
  })
  .then(data => {
    console.log("Ok response"); 
    addRowsToTable(data);
  })
  .catch(error => {
    console.error('There was a problem with the fetch operation:', error);
  });
