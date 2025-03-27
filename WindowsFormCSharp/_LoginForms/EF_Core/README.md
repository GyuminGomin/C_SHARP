```
Entity�� �Ἥ DataSource�� ���ν�Ű��
EF�� DTO�� �Ἥ �����͸� ����� �ٷ� ������ �Ǵ� ������� ����� ���

// �Ʒ��� ���� ������� �����͸� ���ε���Ű�� �ٷ� ���� ����
private void LoadData() {
	using (var db = new AppDbContext())
	{
		// DB���� DTO�� ����
		var projectDtos = db.Products
		                    .Select(p => new ProjectDTO
							{
								Name = p.Name,
								Quantity = p.Quantity
							})
							.toList();
		// ���ε�
		bindingSource.DataSource = productDtos;
	}
}
```