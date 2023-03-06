import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import type { DatePickerProps } from 'antd';
import { Input, notification, DatePicker, Select, Modal, Button } from 'antd';
import dayjs, { Dayjs } from 'dayjs';
import PageLayout from '../components/page-layout';
import { IProcessData } from '../models/process.type';
import { IFormData } from '../models/formData.type';
import { IModalProps } from '../models/modalProps.type';
import { api } from '../services/AxiosService';
import serviceSubjectModal from '../components/processentry/serviceSubjectModal';

const ProcessentryPage = () => {
  const [formData, setFormData] = useState<IProcessData | undefined>(undefined);
  const [formAssociatedData, setFormAssociatedData] = useState<IFormData>();
  const [expireDateTime, setExpireDateTime] = useState(
    formData && formData.expireDateTime ? dayjs(formData.expireDateTime) : null
  );
  const [receivedDateTime, setReceivedDateTime] = useState(
    formData && formData.receivedDateTime
      ? dayjs(formData.receivedDateTime)
      : null
  );
  const [servedDateTime, setServedDateTime] = useState(
    formData && formData.servedDateTime ? dayjs(formData.servedDateTime) : null
  );
  const [isModalVisible, setIsModalVisible] = useState<boolean>(false);

  const params = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    fetchFormAssociatedData();
    if (params.id) {
      fetchProcessData(params.id);
    }
  }, [params.id]);

  const fetchFormAssociatedData = async () => {
    try {
      const response = await api.get<IFormData>('/api/processentryformdata/');
      setFormAssociatedData(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const fetchProcessData = async (id: string) => {
    try {
      const response = await api.get<IProcessData>(`/api/processentries/${id}`);
      setFormData((current) => ({
        ...current,
        ...response.data,
      }));
      if (response.data.expireDateTime != null) {
        setExpireDateTime(dayjs(response.data.expireDateTime));
      }
      if (response.data.receivedDateTime != null) {
        setReceivedDateTime(dayjs(response.data.receivedDateTime));
      }
      if (response.data.servedDateTime != null) {
        setServedDateTime(dayjs(response.data.servedDateTime));
      }
    } catch (e) {
      notification.error({ message: 'Oh no ' });
    }
  };

  const { TextArea } = Input;

  const showModal = () => {
    setIsModalVisible(true);
  };

  const hideModal = () => {
    setIsModalVisible(false);
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleValueChange = (value: number | string | null, key: string) => {
    setFormData((prevState) => ({
      ...prevState,
      [key]: value,
    }));
  };

  const handleExpireDateChange: DatePickerProps['onChange'] = (
    date,
    dateString
  ) => {
    setExpireDateTime(dayjs(dateString));
    setFormData((prevState) => ({
      ...prevState,
      expireDateTime: dateString,
    }));
  };

  const handleReceivedDateChange: DatePickerProps['onChange'] = (
    date,
    dateString
  ) => {
    setReceivedDateTime(dayjs(dateString));
    setFormData((prevState) => ({
      ...prevState,
      receivedDateTime: dateString,
    }));
  };

  const handleServedDateChange: DatePickerProps['onChange'] = (
    date,
    dateString
  ) => {
    setServedDateTime(dayjs(dateString));
    setFormData((prevState) => ({
      ...prevState,
      servedDateTime: dateString,
    }));
  };

  const onSearch = (value: string) => {
    console.log('search:', value);
  };

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(formData);
    try {
      const response = await api.post<IProcessData>(
        '/api/processentries',
        formData
      );
      console.log('post response', response.data);
      if (response.data.id) {
        notification.success({
          message: 'Success!',
          description: 'process has been inserted into you database',
        });
        navigate(`/processentry/${response.data.id?.toString()}`);
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <PageLayout>
      <div className="container mx-auto mt-10 dark:bg-slate-900 dark:text-white">
        <form onSubmit={onSubmit}>
          <div className="grid grid-cols-12 gap-1">
            <div className="col-span-12 text-center">Process Entry</div>
            <div className="col-span-12 md:col-span-2" />
            <div className="col-span-12 md:col-span-8 p-3">
              <serviceSubject
                ModalisModalVisible={isModalVisible}
                showModal={showModal}
                handleCancel={hideModal}
              />
              Client Reference:
              <Input
                id="clientRef"
                className="mb-2 dark:bg-slate-500 dark:text-white"
                placeholder="Client Reference"
                value={formData?.clientRef}
                onChange={handleChange}
              />
              <p>Court Name:</p>
              {Array.isArray(formAssociatedData?.courts) && (
                <Select
                  id="courtId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select a court"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'courtId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.courts.map((court) => ({
                    label: court.name,
                    value: court.id,
                  }))}
                  value={formData?.courtId}
                />
              )}
              <p>Case number:</p>
              <Input
                id="caseNum"
                className="mb-2 dark:bg-slate-500 dark:text-white"
                placeholder="Case Number"
                value={formData?.caseNum}
                onChange={handleChange}
              />
              <p>Priority:</p>
              <Select
                defaultValue="Routine"
                style={{ width: '50%' }}
                onChange={(value: string) =>
                  handleValueChange(value, 'priority')
                }
                options={[
                  { value: 'Routine', label: 'Routine' },
                  { value: 'ASAP', label: 'ASAP' },
                  { value: 'Rush', label: 'Rush' },
                  { value: 'Rush 24 Hours', label: 'Rush 24 Hours' },
                  { value: 'Rush 48 Hours', label: 'Rush 48 Hours' },
                ]}
                value={formData?.priority}
              />
              <p>Compliance Date:</p>
              <DatePicker
                onChange={handleExpireDateChange}
                value={expireDateTime}
              />
              <p>Plaintiff Type:</p>
              {Array.isArray(formAssociatedData?.litigantTypes) && (
                <Select
                  showSearch
                  placeholder="Select plaintiff type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  onChange={(value: number) =>
                    handleValueChange(value, 'plaintiffTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.litigantTypes.map(
                    (litigantType) => ({
                      label: litigantType.name,
                      value: litigantType.id,
                    })
                  )}
                  value={formData?.plaintiffTypeId}
                />
              )}
              <p>Plaintiff Names:</p>
              <Input
                id="plaintiff"
                className=""
                placeholder="Plaintiff names"
                value={formData?.plaintiff}
                onChange={handleChange}
              />
              <p>Defendant Type:</p>
              {Array.isArray(formAssociatedData?.litigantTypes) && (
                <Select
                  showSearch
                  placeholder="Select defendant type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  onChange={(value: number) =>
                    handleValueChange(value, 'defendantTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.litigantTypes.map(
                    (litigantType) => ({
                      label: litigantType.name,
                      value: litigantType.id,
                    })
                  )}
                  value={formData?.defendantTypeId}
                />
              )}
              <p>Defendant Names:</p>
              <Input
                id="defendant"
                className=""
                placeholder="Defendant names"
                value={formData?.defendant}
                onChange={handleChange}
              />
              <p>Received Date:</p>
              <DatePicker
                onChange={handleReceivedDateChange}
                value={receivedDateTime}
              />
              <p>Document to serve:</p>
              {Array.isArray(formAssociatedData?.documents) && (
                <Select
                  id="documentId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select document"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'documentId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.documents.map((document) => ({
                    label: document.name,
                    value: document.id,
                  }))}
                  value={formData?.documentId}
                />
              )}
              <p>Service Subject:</p>
              <p>{formData?.ssId}</p>
              <Button
                className="dark:bg-black dark:text-white mb-4"
                onClick={showModal}
              >
                Service Subject
              </Button>
              <p>Service Instructions:</p>
              {Array.isArray(formAssociatedData?.instructions) && (
                <Select
                  id="instructionId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select instructions"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'instructionId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.instructions.map(
                    (instruction) => ({
                      label: instruction.name,
                      value: instruction.id,
                    })
                  )}
                  value={formData?.instructionId}
                />
              )}
              <p>Server name:</p>
              {Array.isArray(formAssociatedData?.servers) && (
                <Select
                  id="serverId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select process server"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'serverId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.servers.map((server) => ({
                    label: server.name,
                    value: server.id,
                  }))}
                  value={formData?.serverId}
                />
              )}
              -----------
              <h2>Return Fields</h2>
              -----------
              <p>Served Date:</p>
              <DatePicker
                onChange={handleServedDateChange}
                value={servedDateTime}
              />
              <p>Method of service:</p>
              {Array.isArray(formAssociatedData?.methods) && (
                <Select
                  id="methodId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select method of service"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'methodId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.methods.map((method) => ({
                    label: method.name,
                    value: method.id,
                  }))}
                  value={formData?.methodId}
                />
              )}
              <p>Name of Served:</p>
              <Input
                id="subServed"
                className=""
                placeholder="Name of served"
                value={formData?.subServed}
                onChange={handleChange}
              />
              <p>Served Capacity:</p>
              {Array.isArray(formAssociatedData?.capacities) && (
                <Select
                  id="capacityId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select served capacity"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'capacityId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.capacities.map((capacity) => ({
                    label: capacity.name,
                    value: capacity.id,
                  }))}
                  value={formData?.capacityId}
                />
              )}
              <p>Comments:</p>
              <TextArea
                rows={4}
                id="comments"
                onChange={handleChange}
                value={formData?.comments}
              />
              <p>Affidavit Type:</p>
              {Array.isArray(formAssociatedData?.affidavitTypes) && (
                <Select
                  id="affidavitTypeId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select Affidavit Type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'affidavitTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.affidavitTypes.map(
                    (affidavitType) => ({
                      label: affidavitType.name,
                      value: affidavitType.id,
                    })
                  )}
                  value={formData?.affidavitTypeId}
                />
              )}
              <div className="p-3 m-3 text-center">
                <Button
                  htmlType="submit"
                  className="dark:bg-black dark:text-white mb-4"
                >
                  Submit
                </Button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </PageLayout>
  );
};

export default ProcessentryPage;
