fdc<script setup>
import { ref, onMounted } from 'vue'


const departments = ref([])
const maxTotal = ref(0)


onMounted(async () => {
  const response = await fetch('https://localhost:7015/api/analytics/department-load')
  departments.value = await response.json()

 
  if (departments.value.length > 0) {
    maxTotal.value = Math.max(...departments.value.map(d => d.total))
  }
})
</script>

<template>
  <h1>Department Encounter Dashboard</h1>

  <table border="1">
    <tr>
      <th>Department</th>
      <th>Inpatient</th>
      <th>Outpatient</th>
      <th>ED</th>
      <th>Total</th>
    </tr>

    
    <tr
      v-for="d in departments"
      :key="d.departmentName"
      :style="d.total === maxTotal ? 'background-color: red; font-weight: bold;' : ''"
    >
      <td>{{ d.departmentName }}</td>
      <td>{{ d.inpatient }}</td>
      <td>{{ d.outpatient }}</td>
      <td>{{ d.ed }}</td>
      <td>{{ d.total }}</td>
    </tr>
  </table>
</template>





