import { Component, OnInit } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexNonAxisChartSeries,
  ApexChart,
  ApexFill,
  ApexStroke,
  ApexYAxis,
  ApexTooltip,
  ApexMarkers,
  ApexXAxis,
  ApexDataLabels,
  ApexLegend,
  ApexPlotOptions,
  ApexGrid,
  ApexResponsive,
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  series2: ApexNonAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis | ApexYAxis[];
  labels: string[];
  stroke: ApexStroke;
  legend: ApexLegend;
  markers: ApexMarkers;
  dataLabels: ApexDataLabels;
  colors: string[];
  fill: ApexFill;
  grid: ApexGrid;
  tooltip: ApexTooltip;
  plotOptions: ApexPlotOptions;
  responsive: ApexResponsive | ApexResponsive[];
};

export type smallBarChart = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  plotOptions: ApexPlotOptions;
  tooltip: ApexTooltip;
};

@Component({
  selector: 'app-dashboard2',
  templateUrl: './dashboard2.component.html',
  styleUrls: ['./dashboard2.component.sass'],
})
export class Dashboard2Component implements OnInit {
  public lineChartOptions: Partial<ChartOptions>;
  public pieChartOptions: Partial<ChartOptions>;
  public gaugeChartOptions: Partial<ChartOptions>;
  public smallBarChart: any;
  public sampleData = [
    31,
    40,
    28,
    44,
    60,
    55,
    68,
    51,
    42,
    85,
    77,
    31,
    40,
    28,
    44,
    60,
    55,
  ];
  constructor() {}

  ngOnInit(): void {
    this.chart1();
    this.cardChart1();
    this.piechart();
    this.gaugechart();
  }

  private chart1() {
    this.lineChartOptions = {
      series: [
        {
          name: 'Income',
          type: 'area',
          data: [220, 410, 66, 324, 630, 178, 389],
        },
        {
          name: 'Sales',
          type: 'line',
          data: [26, 45, 12, 37, 68, 22, 42],
        },
      ],
      chart: {
        height: 300,
        type: 'area',
        foreColor: '#9aa0ac',
        toolbar: {
          show: false,
        },
      },
      fill: {
        type: 'solid',
        opacity: [0.35, 1],
      },
      stroke: {
        width: [0, 4],
        curve: 'smooth',
      },

      labels: [
        'Sunday',
        'Monday',
        'Tuesday',
        'Wednesday',
        'Thursday',
        'Friday',
        'Saturday',
      ],
      markers: {
        size: 0,
      },
      colors: ['#999999', '#6777EF'],
      dataLabels: {
        enabled: true,
        enabledOnSeries: [1, 2],
      },
      grid: {
        borderColor: '#9aa0ac',
      },
      yaxis: [
        {
          title: {
            text: 'Income',
          },
        },
        {
          opposite: true,
          title: {
            text: 'Sales',
          },
        },
      ],
      xaxis: {
        labels: {
          trim: false,
        },
      },
      tooltip: {
        theme: 'dark',
        marker: {
          show: true,
        },
        x: {
          show: true,
        },
      },
    };
  }
  private cardChart1() {
    this.smallBarChart = {
      chart: {
        type: 'bar',
        width: 200,
        height: 80,
        sparkline: {
          enabled: true,
        },
      },
      plotOptions: {
        bar: {
          columnWidth: '40%',
        },
      },
      series: [
        {
          name: 'income',
          data: this.sampleData,
        },
      ],
      tooltip: {
        fixed: {
          enabled: false,
        },
        x: {
          show: false,
        },
        y: {},
        marker: {
          show: false,
        },
      },
    };
  }
  private piechart() {
    this.pieChartOptions = {
      series2: [18, 22, 14, 31, 15],
      chart: {
        type: 'donut',
        width: 280,
      },
      legend: {
        show: false,
      },
      dataLabels: {
        enabled: false,
      },
      plotOptions: {
        pie: {
          donut: {
            size: '65%',
            background: 'transparent',
            labels: {
              show: true,
              name: {
                show: true,
                fontSize: '22px',
                fontWeight: 600,
              },
              value: {
                show: true,
                fontSize: '16px',
                fontWeight: 400,
                color: '#9aa0ac',
              },
              total: {
                show: true,
                showAlways: false,
                label: 'Total',
                fontSize: '22px',
                fontWeight: 600,
                color: '#6777EF',
              },
            },
          },
        },
      },
      colors: ['#9A8BE7', '#2AC3CB', '#FFAA00', '#FA62BB', '#FFD000'],
      labels: ['Project 1', 'Project 2', 'Project 3', 'Project 4', 'Project 5'],
      responsive: [
        {
          breakpoint: 480,
          options: {},
        },
      ],
    };
  }
  private gaugechart() {
    this.gaugeChartOptions = {
      series2: [72],
      chart: {
        height: 260,
        type: 'radialBar',
        offsetY: -10,
      },
      plotOptions: {
        radialBar: {
          startAngle: -135,
          endAngle: 135,
          dataLabels: {
            name: {
              fontSize: '22px',
              fontWeight: 600,
              color: '#6777EF',
              offsetY: 120,
            },
            value: {
              offsetY: 76,
              fontSize: '22px',
              color: '#9aa0ac',
              formatter: function (val) {
                return val + '%';
              },
            },
          },
        },
      },
      fill: {
        type: 'gradient',
        gradient: {
          shade: 'dark',
          shadeIntensity: 0.15,
          inverseColors: false,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [0, 50, 65, 91],
        },
      },
      stroke: {
        dashArray: 4,
      },
      labels: ['Closed Ticket'],
    };
  }
}
