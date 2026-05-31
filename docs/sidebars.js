/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  tutorialSidebar: [
    {
      type: 'doc',
      id: 'intro',
      label: 'Introduction',
    },
    {
      type: 'doc',
      id: 'getting-started',
      label: 'Getting Started',
    },
    {
      type: 'doc',
      id: 'installation',
      label: 'Installation',
    },
    {
      type: 'doc',
      id: 'configuration',
      label: 'Configuration',
    },
    {
      type: 'category',
      label: 'Features',
      collapsed: false,
      items: [
        'features/map-view',
        'features/photo-list',
        'features/filtering',
        'features/csv-export',
        'features/rename-photos',
      ],
    },
    {
      type: 'doc',
      id: 'troubleshooting',
      label: 'Troubleshooting',
    },
  ],
};

export default sidebars;
