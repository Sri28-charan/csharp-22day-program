<script setup>
import { ref, onMounted } from 'vue'

// Reactive array that will hold patients.
const patients = ref([])
const city=ref('')
const active=ref(true)

// Runs automatically when page loads.
onMounted(async () => {

  // Call ASP.NET Core API. – Change the port
  const response =
    await fetch('https://localhost:7015/api/patients')

  // Convert JSON into JavaScript objects.
  patients.value =  await response.json()

 

})


const searchPatients = async () => {
  const response = await fetch(
    `https://localhost:7015/api/patients/search?city=${city.value}&active=${active.value}`
  )
  patients.value = await response.json()
}




</script>


<template>
  <h1>CareBridge Patients</h1>

 
  <div style="margin-bottom: 10px;">
    <input v-model="city" placeholder="Enter City" />
    
    <select v-model="active">
      <option :value="true">Active</option>
      <option :value="false">Inactive</option>
    </select>

    <button @click="searchPatients">Search</button>
  </div>


  <table border="1">
    <tr>
      <th>Patient Id</th>
      <th>Full Name</th>
      <th>City</th>
      <th>Status</th>
    </tr>

    <tr v-for="p in patients" :key="p.patientId">
      
      <td>{{ p.fullName }}</td>
      <td>{{ p.city }}</td>
      <td>{{ p.isActive ? 'Active' : 'Inactive' }}</td>
    </tr>
  </table>

</template>


