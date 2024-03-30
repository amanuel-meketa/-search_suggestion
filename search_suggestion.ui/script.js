// script.js
const searchInput = document.getElementById('searchInput');
const autocompleteResults = document.getElementById('autocompleteResults');
let debounceTimer;

searchInput.addEventListener('input', function() {
  const searchValue = this.value.trim().toLowerCase();

  // Clear previous debounce timer
  clearTimeout(debounceTimer);

  // Set a new debounce timer to delay API call
  debounceTimer = setTimeout(() => {
    if (searchValue.length > 0) {
      showLoadingIndicator();
      fetch('http://localhost:8080/api/Comment')
        .then(response => {
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
          return response.json();
        })
        .then(data => {
          const matches = data.filter(item => item.name.toLowerCase().includes(searchValue));
          displayMatches(matches);
        })
        .catch(error => {
          console.error('Error fetching data:', error);
          displayError('Failed to fetch data. Please try again.');
        });
    } else {
      clearResults();
    }
  }, 300); // Adjust debounce delay as needed
});

function displayMatches(matches) {
  const html = matches.map(match => {
    return `<div class="autocomplete-result">${match.name}</div>`;
  }).join('');

  hideLoadingIndicator();
  autocompleteResults.innerHTML = html;
  autocompleteResults.style.display = 'block';
}

function clearResults() {
  autocompleteResults.innerHTML = '';
  autocompleteResults.style.display = 'none';
}

function showLoadingIndicator() {
  clearResults();
  autocompleteResults.innerHTML = '<div class="loading-indicator">Loading...</div>';
}

function hideLoadingIndicator() {
  const loadingIndicator = document.querySelector('.loading-indicator');
  if (loadingIndicator) {
    loadingIndicator.parentNode.removeChild(loadingIndicator);
  }
}

function displayError(message) {
  hideLoadingIndicator();
  autocompleteResults.innerHTML = `<div class="error-message">${message}</div>`;
}

window.addEventListener('click', function(event) {
  if (!searchInput.contains(event.target)) {
    clearResults();
  }
});
