import React from 'react'
import { PageLayout } from '../components/page-layout'
import axios from "axios"
import { api } from '../services/AxiosService'

const ProcessentryPage = () => {
  
const fetchData = () => {
  return api.get("/api/processentries/6007")
     .then((response) => console.log(response.data));
  };

  fetchData();
  return (
    <PageLayout>
      <div className="container-fl">processentryPage</div>
    </PageLayout>
    
  )
}

export default ProcessentryPage;