import React, { useState } from 'react';
import { Button, Modal } from 'antd';

interface IModalProps {
  visible: boolean;
  onCancel: () => void;
}

const ModalServiceSubject = ({
  visible,
  onCancel,
}: IModalProps): JSX.Element => (
  <Modal
    open={visible}
    onCancel={onCancel}
    title="Service Subject"
    footer={[
      <Button key="cancel" onClick={onCancel}>
        Cancel
      </Button>,
      <Button key="submit" type="primary">
        Submit
      </Button>,
    ]}
  >
    <p>This is the content of the modal.</p>
  </Modal>
);
export default ModalServiceSubject;
